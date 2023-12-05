namespace GqlPlus.Verifier.Verification;

public interface IVerify<TTarget>
{
  bool Verify<TContext>(TContext context, TTarget target)
    where TContext : VerificationContext;
}
