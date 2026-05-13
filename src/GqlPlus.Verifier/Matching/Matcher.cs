using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

public interface IMatcher<T>
{
  bool Matches(T type, string constraint, EnumContext context);
}

public class Matcher<T>(
  Matcher<T>.D factory
) : DeferOne<IMatcher<T>>(factory)
  , IMatcher<T>
{
  public bool Matches(T type, string constraint, EnumContext context)
    => Value.Matches(type, constraint, context);

  public static implicit operator Matcher<T>(D factory)
    => new(factory.ThrowIfNull());
}

public interface ITypeMatcher
{
  bool MatchesTypeConstraint(IAstType type, string constraint, EnumContext context);
}

public interface IConstraintMatcher<TType>
  : ITypeMatcher
  where TType : IAstType
{
  bool MatchesConstraint(IAstType type, TType constraint, EnumContext context);
}
