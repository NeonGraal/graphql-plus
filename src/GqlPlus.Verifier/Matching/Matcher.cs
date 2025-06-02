using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

#pragma warning disable CA1034 // Nested types should not be visible
public static class Matcher<T>
{
  public interface I
  {
    bool Matches(T type, string constraint, EnumContext context);
  }

  public delegate I D();

  public class L(D factory) : Lazy<I>(() => factory())
  {
    public static implicit operator L(D factory) => new(factory.ThrowIfNull());

    public bool Matches(T type, string constraint, EnumContext context)

      => Value.Matches(type, constraint, context);
  }
}

public interface ITypeMatcher
{
  bool MatchesTypeConstraint(IGqlpType type, string constraint, EnumContext context);
}
