﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputBaseTests
  : ObjectParseTestBase<IGqlpInputBase, IGqlpObjArg>
{
  public ParseInputBaseTests()
    => BaseParser = new ParseInputBase(ParseArgs);

  protected override Parser<IGqlpInputBase>.I BaseParser { get; }
}
