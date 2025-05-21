using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseEndFragmentsTests
  : ParseFragmentsTestsBase
{
  public ParseEndFragmentsTests()
  {
    Parser<IGqlpDirective>.DA directives = ParserAFor(out Parser<IGqlpDirective>.IA directivesParser);
    Parser<IGqlpSelection>.DA objectDelegate = ParserAFor(out Parser<IGqlpSelection>.IA objectParser);

    DirectivesParser = directivesParser;
    ObjectParser = objectParser;

    Parser = new ParseEndFragments(directives, objectDelegate);
  }

  protected override Parser<IGqlpFragment>.IA Parser { get; }
  protected override Parser<IGqlpDirective>.IA DirectivesParser { get; }
  protected override Parser<IGqlpSelection>.IA ObjectParser { get; }

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
    Parser<IGqlpDirective>.DA directives = ParserAFor(out Parser<IGqlpDirective>.IA directivesParser);
    Parser<IGqlpSelection>.DA objectDelegate = ParserAFor(out Parser<IGqlpSelection>.IA objectParser);

    DirectivesParser = directivesParser;
    ObjectParser = objectParser;

    Parser = new ParseStartFragments(directives, objectDelegate);
  }

  protected override Parser<IGqlpFragment>.IA Parser { get; }
  protected override Parser<IGqlpDirective>.IA DirectivesParser { get; }
  protected override Parser<IGqlpSelection>.IA ObjectParser { get; }

  protected override void SetupFragmentPrefix(bool value)
    => TakeReturns('&', value, false);

  protected override void SetupTypePrefix(bool value)
    => TakeReturns(':', value, false);
}
