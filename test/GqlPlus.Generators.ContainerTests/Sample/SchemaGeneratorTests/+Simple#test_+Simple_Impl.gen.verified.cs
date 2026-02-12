//HintName: test_+Simple_Impl.gen.cs
// Generated from +Simple.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public class testDmnBoolDescr
  : GqlpDomainBoolean
  , ItestDmnBoolDescr
{
}

public class testDmnBoolPrnt
  : testPrntDmnBoolPrnt
  , ItestDmnBoolPrnt
{
}

public class testPrntDmnBoolPrnt
  : GqlpDomainBoolean
  , ItestPrntDmnBoolPrnt
{
}

public class testDmnBoolPrntDescr
  : testPrntDmnBoolPrntDescr
  , ItestDmnBoolPrntDescr
{
}

public class testPrntDmnBoolPrntDescr
  : GqlpDomainBoolean
  , ItestPrntDmnBoolPrntDescr
{
}

public class testDmnEnumAll
  : GqlpDomainEnum
  , ItestDmnEnumAll
{
}

public class testDmnEnumAllDescr
  : GqlpDomainEnum
  , ItestDmnEnumAllDescr
{
}

public class testDmnEnumAllPrnt
  : GqlpDomainEnum
  , ItestDmnEnumAllPrnt
{
}

public class testDmnEnumDescr
  : GqlpDomainEnum
  , ItestDmnEnumDescr
{
}

public class testDmnEnumExcl
  : GqlpDomainEnum
  , ItestDmnEnumExcl
{
}

public class testDmnEnumExclPrnt
  : GqlpDomainEnum
  , ItestDmnEnumExclPrnt
{
}

public class testDmnEnumLabel
  : GqlpDomainEnum
  , ItestDmnEnumLabel
{
}

public class testDmnEnumPrnt
  : testPrntDmnEnumPrnt
  , ItestDmnEnumPrnt
{
}

public class testPrntDmnEnumPrnt
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrnt
{
}

public class testDmnEnumPrntDescr
  : testPrntDmnEnumPrntDescr
  , ItestDmnEnumPrntDescr
{
}

public class testPrntDmnEnumPrntDescr
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrntDescr
{
}

public class testDmnEnumUnq
  : GqlpDomainEnum
  , ItestDmnEnumUnq
{
}

public class testDmnEnumUnqPrnt
  : GqlpDomainEnum
  , ItestDmnEnumUnqPrnt
{
}

public class testDmnEnumValue
  : GqlpDomainEnum
  , ItestDmnEnumValue
{
}

public class testDmnEnumValuePrnt
  : GqlpDomainEnum
  , ItestDmnEnumValuePrnt
{
}

public class testDmnNmbrDescr
  : GqlpDomainNumber
  , ItestDmnNmbrDescr
{
}

public class testDmnNmbrPrnt
  : testPrntDmnNmbrPrnt
  , ItestDmnNmbrPrnt
{
}

public class testPrntDmnNmbrPrnt
  : GqlpDomainNumber
  , ItestPrntDmnNmbrPrnt
{
}

public class testDmnNmbrPrntDescr
  : testPrntDmnNmbrPrntDescr
  , ItestDmnNmbrPrntDescr
{
}

public class testPrntDmnNmbrPrntDescr
  : GqlpDomainNumber
  , ItestPrntDmnNmbrPrntDescr
{
}

public class testDmnNmbrPstv
  : GqlpDomainNumber
  , ItestDmnNmbrPstv
{
}

public class testDmnNmbrRange
  : GqlpDomainNumber
  , ItestDmnNmbrRange
{
}

public class testDmnStrDescr
  : GqlpDomainString
  , ItestDmnStrDescr
{
}

public class testDmnStrNonEmpty
  : GqlpDomainString
  , ItestDmnStrNonEmpty
{
}

public class testDmnStrPrnt
  : testPrntDmnStrPrnt
  , ItestDmnStrPrnt
{
}

public class testPrntDmnStrPrnt
  : GqlpDomainString
  , ItestPrntDmnStrPrnt
{
}

public class testDmnStrPrntDescr
  : testPrntDmnStrPrntDescr
  , ItestDmnStrPrntDescr
{
}

public class testPrntDmnStrPrntDescr
  : GqlpDomainString
  , ItestPrntDmnStrPrntDescr
{
}

public class testUnionDescr
  : ItestUnionDescr
{
  public Number AsNumber { get; set; }
}

public class testUnionPrnt
  : testPrntUnionPrnt
  , ItestUnionPrnt
{
  public String AsString { get; set; }
}

public class testPrntUnionPrnt
  : ItestPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}

public class testUnionPrntDescr
  : testPrntUnionPrntDescr
  , ItestUnionPrntDescr
{
  public Number AsNumber { get; set; }
}

public class testPrntUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
  public Number AsNumber { get; set; }
}

public class testUnionPrntDup
  : testPrntUnionPrntDup
  , ItestUnionPrntDup
{
  public Number AsNumber { get; set; }
}

public class testPrntUnionPrntDup
  : ItestPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
