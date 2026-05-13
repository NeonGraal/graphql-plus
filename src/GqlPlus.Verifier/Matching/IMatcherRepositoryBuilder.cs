using GqlPlus.Ast.Schema;

namespace GqlPlus.Matching;

public interface IMatcherRepositoryBuilder
{
  IMatcherRepositoryBuilder AddMatcher<T>(Factory<IMatcher<T>, IMatcherRepository> factory);

  IMatcherRepositoryBuilder AddTypeMatcher<T, TMatcher>(Factory<TMatcher, IMatcherRepository> factory)
    where T : IAstType
    where TMatcher : class, IMatcher<T>, ITypeMatcher;

  IMatcherRepositoryBuilder AddConstraintMatcher(Factory<ITypeMatcher, IMatcherRepository> factory);
}
