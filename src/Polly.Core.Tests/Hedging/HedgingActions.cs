using Polly.Hedging;
using Polly.Utils;

namespace Polly.Core.Tests.Hedging;

internal class HedgingActions
{
    private readonly TimeProvider _timeProvider;

    public HedgingActions(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;

        Functions = new()
        {
            GetApples,
            GetOranges,
            GetPears
        };

        Generator = args =>
        {
            if (args.Attempt <= Functions.Count)
            {
                return async () =>
                {
                    return await Functions[args.Attempt - 1]!(args.Context);
                };
            }

            return null;
        };
    }

    public Func<HedgingActionGeneratorArguments<string>, Func<ValueTask<Outcome<string>>>?> Generator { get; }

    public Func<HedgingActionGeneratorArguments<string>, Func<ValueTask<Outcome<string>>>?> EmptyFunctionsProvider { get; } = args => null;

    public List<Func<ResilienceContext, ValueTask<Outcome<string>>>> Functions { get; }

    private async ValueTask<Outcome<string>> GetApples(ResilienceContext context)
    {
        await _timeProvider.Delay(TimeSpan.FromSeconds(10), context.CancellationToken);
        return "Apples".AsOutcome();
    }

    private async ValueTask<Outcome<string>> GetPears(ResilienceContext context)
    {
        await _timeProvider.Delay(TimeSpan.FromSeconds(3), context.CancellationToken);
        return "Pears".AsOutcome();
    }

    private async ValueTask<Outcome<string>> GetOranges(ResilienceContext context)
    {
        await _timeProvider.Delay(TimeSpan.FromSeconds(2), context.CancellationToken);
        return "Oranges".AsOutcome();
    }

    public static Func<HedgingActionGeneratorArguments<string>, Func<ValueTask<Outcome<string>>>?> GetGenerator(Func<ResilienceContext, ValueTask<Outcome<string>>> task)
    {
        return args => () => task(args.Context);
    }

    public int MaxHedgedTasks => Functions.Count + 1;
}
