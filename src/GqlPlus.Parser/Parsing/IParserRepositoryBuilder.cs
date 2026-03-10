using GqlPlus.Parsing.Schema;

namespace GqlPlus.Parsing;

public interface IParserRepositoryBuilder
{
  IParserRepositoryBuilder AddSingle<T>(Factory<Parser<T>.I, IParserRepository> factory);

  IParserRepositoryBuilder AddArray<T>(Factory<Parser<T>.IA, IParserRepository> factory);

  IParserRepositoryBuilder AddInterfaceSingle<T>(Factory<T, IParserRepository> factory)
    where T : class;

  IParserRepositoryBuilder AddInterfaceArray<T>(Factory<T, IParserRepository> factory)
    where T : class;

  IParserRepositoryBuilder AddDomain<T>();

  IParserRepositoryBuilder AddDeclaration<T>(Factory<IParseDeclaration, IParserRepository> factory);
}
