# Polly Documentation

Polly is a .NET resilience and transient-fault-handling library that allows developers to express resilience strategies such as Retry, Circuit Breaker, Hedging, Timeout, Rate Limiter and Fallback in a fluent and thread-safe manner.

We are a member of the [.NET Foundation](https://www.dotnetfoundation.org/about)!

![Polly logo](https://raw.github.com/App-vNext/Polly/main/Polly-Logo.png)

## Resilience strategies

| Strategy | Reactive | Premise | AKA | How does the strategy mitigate?|
| ------------- | --- | ------------- |:-------------: |------------- |
|[Retry](strategies/retry.md) |Yes|Many faults are transient and may self-correct after a short delay.| *Maybe it's just a blip* |  Allows configuring automatic retries. |
|[Circuit-breaker](strategies/circuit-breaker.md) |Yes|When a system is seriously struggling, failing fast is better than making users/callers wait.  <br/><br/>Protecting a faulting system from overload can help it recover. | *Stop doing it if it hurts* <br/><br/>*Give that system a break* | Breaks the circuit (blocks executions) for a period, when faults exceed some pre-configured threshold. |
|[Timeout](strategies/timeout.md)|No|Beyond a certain wait, a success result is unlikely.| *Don't wait forever*  |Guarantees the caller won't have to wait beyond the timeout. |
|[Rate Limiter](strategies/rate-limiter.md)|No|Limiting the rate a system handles requests is another way to control load. <br/><br/> This can apply to the way your system accepts incoming calls, and/or to the way you call downstream services. | *Slow down a bit, will you?*  |Constrains executions to not exceed a certain rate. |
|[Fallback](strategies/fallback.md)|Yes|Things will still fail - plan what you will do when that happens.| *Degrade gracefully*  |Defines an alternative value to be returned (or action to be executed) on failure. |
|[Hedging](strategies/hedging.md)|Yes|Things can be slow sometimes, plan what you will do when that happens.| *Hedge your bets*  | Executes parallel actions when things are slow and waits for the fastest one.  |

Visit the [resilience strategies](strategies/readme.md) section to understand their structure and explore various configuration methods.

## Next steps

Visit the [getting started](getting-started.md) section and learn how to quickly start using Polly.

## Articles

- [Introduction](readme.md): General information about the project and its goals.
- [Getting started](getting-started.md): A guide to help you get started with the project.
- Resilience strategies: A collection of strategies for improving the resilience of your system.
  - [Timeout](strategies/timeout.md): A strategy for setting a maximum time limit for a request.
  - [Retry](strategies/retry.md): A strategy for retrying failed requests.
  - [Rate limiter](strategies/rate-limiter.md): A strategy for limiting the rate of requests.
  - [Hedging](strategies/hedging.md): A strategy for hedging against long request times.
  - [Fallback](strategies/fallback.md): A strategy for providing a fallback response in case of failure.
  - [Circuit breaker](strategies/circuit-breaker.md): A strategy for breaking the circuit when a system is down.
- Resilience pipelines: Understanding the use of resilience pipelines.
  - [Resilience pipeline registry](pipelines/resilience-pipeline-registry.md): Exploring the registry that stores resilience pipelines.
- vanced topics: A collection of advanced topics for further learning.
  - [Telemetry and monitoring](advanced/telemetry.md): Insights into telemetry generated by resilience pipelines and strategies.
  - [Chaos engineering](advanced/simmy.md): Get to know chaos engineering via the project's capabilities.
  - [Dependency injection](advanced/dependency-injection.md): How the project integrates with Dependency Injection.
- Community and resources: A collection of resources and community contributions.
  - [Polly-Contrib projects and libraries](community/polly-contrib.md): Learn how to contribute to and extend the project ecosystem.
  - [Libraries and contributions](community/libraries-and-contributions.md): Find out which libraries the project depends on and who contributes to its development.
  - [Useful resources and links](community/resources.md): Browse through blogs, podcasts, courses, e-books, and other community resources.
- [API](api/readme.md): The API documentation for the project.

## Articles (previous Polly versions)

- [Extensibility (v7)](v7/extensibility.md): Learn how you can extend Polly with new policies.

## Samples

- [Samples](https://github.com/App-vNext/Polly/tree/main/samples): Samples in this repository that serve as an introduction to Polly.
- [Polly-Samples](https://github.com/App-vNext/Polly-Samples): Contains practical examples for using various implementations of Polly. Please feel free to contribute to the Polly-Samples repository in order to assist others who are either learning Polly for the first time, or are seeking advanced examples and novel approaches provided by our generous community.
- Microsoft's [eShopOnContainers project](https://github.com/dotnet-architecture/eShopOnContainers): Sample project demonstrating a .NET Microservices architecture and using Polly for resilience.