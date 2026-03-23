//HintName: test_+Simple_Model.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  public new testEnumDmnEnumAll? Value { get; set; }
}

public class testDmnEnumAllDescr
  : GqlpDomainEnum
  , ItestDmnEnumAllDescr
{
  public new testEnumDmnEnumAllDescr? Value { get; set; }
}

public class testDmnEnumAllPrnt
  : GqlpDomainEnum
  , ItestDmnEnumAllPrnt
{
  public new testEnumDmnEnumAllPrnt? Value { get; set; }
}

public class testDmnEnumDescr
  : GqlpDomainEnum
  , ItestDmnEnumDescr
{
  public new testEnumDmnEnumDescr? Value { get; set; }
}

public class testDmnEnumExcl
  : GqlpDomainEnum
  , ItestDmnEnumExcl
{
  public new testEnumDmnEnumExcl? Value { get; set; }
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
  public new testEnumDmnEnumLabel? Value { get; set; }
}

public class testDmnEnumPrnt
  : testPrntDmnEnumPrnt
  , ItestDmnEnumPrnt
{
  public new testEnumDmnEnumPrnt? Value { get; set; }
}

public class testPrntDmnEnumPrnt
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrnt
{
  public new testEnumDmnEnumPrnt? Value { get; set; }
}

public class testDmnEnumPrntDescr
  : testPrntDmnEnumPrntDescr
  , ItestDmnEnumPrntDescr
{
  public new testEnumDmnEnumPrntDescr? Value { get; set; }
}

public class testPrntDmnEnumPrntDescr
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrntDescr
{
  public new testEnumDmnEnumPrntDescr? Value { get; set; }
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
  public new testEnumDmnEnumValue? Value { get; set; }
}

public class testDmnEnumValuePrnt
  : GqlpDomainEnum
  , ItestDmnEnumValuePrnt
{
  public new testEnumDmnEnumValuePrnt? Value { get; set; }
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
  : GqlpModelImplementationBase
  , ItestUnionDescr
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
  : GqlpModelImplementationBase
  , ItestPrntUnionPrnt
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
  : GqlpModelImplementationBase
  , ItestPrntUnionPrntDescr
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
  : GqlpModelImplementationBase
  , ItestPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
