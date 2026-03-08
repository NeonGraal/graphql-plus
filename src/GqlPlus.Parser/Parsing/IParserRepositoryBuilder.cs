using GqlPlus.Parsing.Schema;

namespace GqlPlus.Parsing;

public interface IParserRepositoryBuilder
{
  IParserRepositoryBuilder AddSingle<T>(ParserFactory<Parser<T>.I> factory);

  IParserRepositoryBuilder AddArray<T>(ParserFactory<Parser<T>.IA> factory);

  IParserRepositoryBuilder AddInterfaceSingle<T>(ParserFactory<T> factory)
    where T : class;

  IParserRepositoryBuilder AddInterfaceArray<T>(ParserFactory<T> factory)
    where T : class;

  IParserRepositoryBuilder AddDomain<T>();

  IParserRepositoryBuilder AddDeclaration<T>(ParserFactory<IParseDeclaration> factory);
}

public delegate T ParserFactory<out T>(IParserRepository parsers)
  where T : class;
