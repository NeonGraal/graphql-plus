//HintName: test_+Simple_Impl.gen.cs
// Generated from +Simple.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public class testDmnBoolDescr
  : DomainBoolean
  , ItestDmnBoolDescr
{
}

public class testDmnBoolPrnt
  : testPrntDmnBoolPrnt
  , ItestDmnBoolPrnt
{
}

public class testPrntDmnBoolPrnt
  : DomainBoolean
  , ItestPrntDmnBoolPrnt
{
}

public class testDmnBoolPrntDescr
  : testPrntDmnBoolPrntDescr
  , ItestDmnBoolPrntDescr
{
}

public class testPrntDmnBoolPrntDescr
  : DomainBoolean
  , ItestPrntDmnBoolPrntDescr
{
}

public class testDmnEnumAll
  : DomainEnum
  , ItestDmnEnumAll
{
}

public class testDmnEnumAllDescr
  : DomainEnum
  , ItestDmnEnumAllDescr
{
}

public class testDmnEnumAllPrnt
  : DomainEnum
  , ItestDmnEnumAllPrnt
{
}

public class testDmnEnumDescr
  : DomainEnum
  , ItestDmnEnumDescr
{
}

public class testDmnEnumLabel
  : DomainEnum
  , ItestDmnEnumLabel
{
}

public class testDmnEnumPrnt
  : testPrntDmnEnumPrnt
  , ItestDmnEnumPrnt
{
}

public class testPrntDmnEnumPrnt
  : DomainEnum
  , ItestPrntDmnEnumPrnt
{
}

public class testDmnEnumPrntDescr
  : testPrntDmnEnumPrntDescr
  , ItestDmnEnumPrntDescr
{
}

public class testPrntDmnEnumPrntDescr
  : DomainEnum
  , ItestPrntDmnEnumPrntDescr
{
}

public class testDmnEnumValue
  : DomainEnum
  , ItestDmnEnumValue
{
}

public class testDmnEnumValuePrnt
  : DomainEnum
  , ItestDmnEnumValuePrnt
{
}

public class testDmnNmbrDescr
  : DomainNumber
  , ItestDmnNmbrDescr
{
}

public class testDmnNmbrPrnt
  : testPrntDmnNmbrPrnt
  , ItestDmnNmbrPrnt
{
}

public class testPrntDmnNmbrPrnt
  : DomainNumber
  , ItestPrntDmnNmbrPrnt
{
}

public class testDmnNmbrPrntDescr
  : testPrntDmnNmbrPrntDescr
  , ItestDmnNmbrPrntDescr
{
}

public class testPrntDmnNmbrPrntDescr
  : DomainNumber
  , ItestPrntDmnNmbrPrntDescr
{
}

public class testDmnStrDescr
  : DomainString
  , ItestDmnStrDescr
{
}

public class testDmnStrPrnt
  : testPrntDmnStrPrnt
  , ItestDmnStrPrnt
{
}

public class testPrntDmnStrPrnt
  : DomainString
  , ItestPrntDmnStrPrnt
{
}

public class testDmnStrPrntDescr
  : testPrntDmnStrPrntDescr
  , ItestDmnStrPrntDescr
{
}

public class testPrntDmnStrPrntDescr
  : DomainString
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
