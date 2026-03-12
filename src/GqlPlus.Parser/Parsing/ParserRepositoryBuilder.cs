using GqlPlus.Parsing.Schema;

namespace GqlPlus.Parsing;

internal class ParserRepositoryBuilder
  : BaseFactory<IParserRepository>, IParserRepositoryBuilder
{
  internal readonly FactoryDict Singles = [];
  internal readonly FactoryDict Arrays = [];
  internal readonly FactoryDict InterfaceSingles = [];
  internal readonly FactoryDict InterfaceArrays = [];
  internal readonly FactoryDict Declarations = [];
  internal readonly Dictionary<Type, Type> Domains = [];

  public IParserRepositoryBuilder AddSingle<T>(Factory<Parser<T>.I, IParserRepository> factory)
    => this.FluentAction(b => b.Singles[typeof(T)] = factory);

  public IParserRepositoryBuilder AddArray<T>(Factory<Parser<T>.IA, IParserRepository> factory)
    => this.FluentAction(b => b.Arrays[typeof(T)] = factory);

  public IParserRepositoryBuilder AddInterfaceSingle<T>(Factory<T, IParserRepository> factory)
    where T : class
    => this.FluentAction(b => b.InterfaceSingles[typeof(T)] = factory);

  public IParserRepositoryBuilder AddInterfaceArray<T>(Factory<T, IParserRepository> factory)
    where T : class
    => this.FluentAction(b => b.InterfaceArrays[typeof(T)] = factory);

  public IParserRepositoryBuilder AddDomain<T>()
    => this.FluentAction(b => b.Domains[typeof(T)] = typeof(Parser<T>.I));

  public IParserRepositoryBuilder AddDeclaration<T>(Factory<IParseDeclaration, IParserRepository> factory)
    => this.FluentAction(b => b.Declarations[typeof(T)] = factory);
}
