using GqlPlus.Parsing.Schema;

namespace GqlPlus.Parsing;

internal class ParserRepositoryBuilder
  : IParserRepositoryBuilder
{
  internal readonly FactoryDict Singles = [];
  internal readonly FactoryDict Arrays = [];
  internal readonly FactoryDict InterfaceSingles = [];
  internal readonly FactoryDict InterfaceArrays = [];
  internal readonly FactoryDict Declarations = [];
  internal readonly Dictionary<Type, Type> Domains = [];

  public IParserRepositoryBuilder AddSingle<T>(ParserFactory<Parser<T>.I> factory)
    => this.FluentAction(b => b.Singles[typeof(T)] = factory);

  public IParserRepositoryBuilder AddArray<T>(ParserFactory<Parser<T>.IA> factory)
    => this.FluentAction(b => b.Arrays[typeof(T)] = factory);

  public IParserRepositoryBuilder AddInterfaceSingle<T>(ParserFactory<T> factory)
    where T : class
    => this.FluentAction(b => b.InterfaceSingles[typeof(T)] = factory);

  public IParserRepositoryBuilder AddInterfaceArray<T>(ParserFactory<T> factory)
    where T : class
    => this.FluentAction(b => b.InterfaceArrays[typeof(T)] = factory);

  public IParserRepositoryBuilder AddDomain<T>()
    => this.FluentAction(b => b.Domains[typeof(T)] = typeof(Parser<T>.I));

  public IParserRepositoryBuilder AddDeclaration<T>(ParserFactory<IParseDeclaration> factory)
    => this.FluentAction(b => b.Declarations[typeof(T)] = factory);
}

internal class FactoryDict : Dictionary<Type, ParserFactory<object>>;
