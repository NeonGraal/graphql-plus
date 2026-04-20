using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseEndFragmentsTests
  : ParseFragmentsTestsBase
{
  public ParseEndFragmentsTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepoArray<IAstDirective>(parsers, out Parser<IAstDirective>.IA directivesParser);
    ConfigureRepoArray<IAstSelection>(parsers, out Parser<IAstSelection>.IA objectParser);
    DirectivesParser = directivesParser;
    ObjectParser = objectParser;
    Parser = new ParseEndFragments(parsers);
  }

  protected override Parser<IAstFragment>.IA Parser { get; }
  protected override Parser<IAstDirective>.IA DirectivesParser { get; }
  protected override Parser<IAstSelection>.IA ObjectParser { get; }

  protected override void SetupFragmentPrefix(bool value)
    => TakeReturns("fragment", value, false);

  protected override void SetupTypePrefix(bool value)
    => TakeReturns("on", value, false);
}

public class ParseStartFragmentsTests
  : ParseFragmentsTestsBase
{
  public ParseStartFragmentsTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepoArray<IAstDirective>(parsers, out Parser<IAstDirective>.IA directivesParser);
    ConfigureRepoArray<IAstSelection>(parsers, out Parser<IAstSelection>.IA objectParser);
    DirectivesParser = directivesParser;
    ObjectParser = objectParser;
    Parser = new ParseStartFragments(parsers);
  }

  protected override Parser<IAstFragment>.IA Parser { get; }
  protected override Parser<IAstDirective>.IA DirectivesParser { get; }
  protected override Parser<IAstSelection>.IA ObjectParser { get; }

  protected override void SetupFragmentPrefix(bool value)
    => TakeReturns('&', value, false);

  protected override void SetupTypePrefix(bool value)
    => TakeReturns(':', value, false);
}
