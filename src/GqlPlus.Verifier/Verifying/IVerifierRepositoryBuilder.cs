using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

public interface IVerifierRepositoryBuilder
{
  IVerifierRepositoryBuilder AddVerify<T>(Factory<IVerify<T>, IVerifierRepository> factory);

  IVerifierRepositoryBuilder TryAddVerify<T>(Factory<IVerify<T>, IVerifierRepository> factory);

  IVerifierRepositoryBuilder AddAliased<T>(Factory<IVerifyAliased<T>, IVerifierRepository> factory)
    where T : IGqlpAliased;

  IVerifierRepositoryBuilder AddUsage<T>(Factory<IVerifyUsage<T>, IVerifierRepository> factory)
    where T : IGqlpAliased;

  IVerifierRepositoryBuilder AddIdentified<TUsage, TIdentified>(Factory<IVerifyIdentified<TUsage, TIdentified>, IVerifierRepository> factory)
    where TUsage : IAstError
    where TIdentified : IGqlpIdentified;

  IVerifierRepositoryBuilder AddDomain(Factory<IVerifyDomain, IVerifierRepository> factory);
}
