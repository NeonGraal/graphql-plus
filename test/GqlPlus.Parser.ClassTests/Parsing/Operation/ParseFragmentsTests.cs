using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseEndFragmentsTests
  : ParseFragmentsTestsBase
{
  public ParseEndFragmentsTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepoArray<IAstDirective>(parsers, out IParserArray<IAstDirective> directivesParser);
    ConfigureRepoArray<IAstSelection>(parsers, out IParserArray<IAstSelection> objectParser);
    DirectivesParser = directivesParser;
    ObjectParser = objectParser;
    Parser = new ParseEndFragments(parsers);
  }

  protected override IParserArray<IAstFragment> Parser { get; }
  protected override IParserArray<IAstDirective> DirectivesParser { get; }
  protected override IParserArray<IAstSelection> ObjectParser { get; }

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
    ConfigureRepoArray<IAstDirective>(parsers, out IParserArray<IAstDirective> directivesParser);
    ConfigureRepoArray<IAstSelection>(parsers, out IParserArray<IAstSelection> objectParser);
    DirectivesParser = directivesParser;
    ObjectParser = objectParser;
    Parser = new ParseStartFragments(parsers);
  }

  protected override IParserArray<IAstFragment> Parser { get; }
  protected override IParserArray<IAstDirective> DirectivesParser { get; }
  protected override IParserArray<IAstSelection> ObjectParser { get; }

  protected override void SetupFragmentPrefix(bool value)
    => TakeReturns('&', value, false);

  protected override void SetupTypePrefix(bool value)
    => TakeReturns(':', value, false);
}
