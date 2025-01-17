using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Npgsql.Internal;

namespace Npgsql;

sealed record NpgsqlDataSourceConfiguration(string? Name,
    NpgsqlLoggingConfiguration LoggingConfiguration,
    NpgsqlTracingOptions? TracingOptions,
    TransportSecurityHandler TransportSecurityHandler,
    IntegratedSecurityHandler userCertificateValidationCallback,
    Action<SslClientAuthenticationOptions>? SslClientAuthenticationOptionsCallback,
    Func<NpgsqlConnectionStringBuilder, string>? PasswordProvider,
    Func<NpgsqlConnectionStringBuilder, CancellationToken, ValueTask<string>>? PasswordProviderAsync,
    Func<NpgsqlConnectionStringBuilder, CancellationToken, ValueTask<string>>? PeriodicPasswordProvider,
    TimeSpan PeriodicPasswordSuccessRefreshInterval,
    TimeSpan PeriodicPasswordFailureRefreshInterval,
    PgTypeInfoResolverChain ResolverChain,
    INpgsqlNameTranslator DefaultNameTranslator,
    Action<NpgsqlConnection>? ConnectionInitializer,
    Func<NpgsqlConnection, Task>? ConnectionInitializerAsync
#if NET7_0_OR_GREATER
    ,Action<NegotiateAuthenticationClientOptions>? NegotiateOptionsCallback
#endif
    );
