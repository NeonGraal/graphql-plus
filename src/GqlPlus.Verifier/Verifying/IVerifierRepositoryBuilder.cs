using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

public interface IVerifierRepositoryBuilder
{
  IVerifierRepositoryBuilder AddVerify<T>(VerifierFactory<IVerify<T>> factory);

  IVerifierRepositoryBuilder TryAddVerify<T>(VerifierFactory<IVerify<T>> factory);

  IVerifierRepositoryBuilder AddAliased<T>(VerifierFactory<IVerifyAliased<T>> factory)
    where T : IGqlpAliased;

  IVerifierRepositoryBuilder AddUsage<T>(VerifierFactory<IVerifyUsage<T>> factory)
    where T : IGqlpAliased;

  IVerifierRepositoryBuilder AddIdentified<TUsage, TIdentified>(VerifierFactory<IVerifyIdentified<TUsage, TIdentified>> factory)
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified;

  IVerifierRepositoryBuilder AddDomain(VerifierFactory<IVerifyDomain> factory);
}

public delegate T VerifierFactory<out T>(IVerifierRepository verifiers)
  where T : class;
