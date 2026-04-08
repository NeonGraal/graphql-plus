//HintName: test_+Simple_Enc.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
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
}

public enum testEnumDmnEnumAll
{
  dmnEnumAll,
  enum_dmnEnumAll,
  dmnEnumAllValue,
}

public class testDmnEnumAllDescr
  : GqlpDomainEnum
  , ItestDmnEnumAllDescr
{
}

public enum testEnumDmnEnumAllDescr
{
  dmnEnumAllDescr,
  enum_dmnEnumAllDescr,
  dmnEnumAllDescrValue,
}

public class testDmnEnumAllPrnt
  : GqlpDomainEnum
  , ItestDmnEnumAllPrnt
{
}

public enum testEnumDmnEnumAllPrnt
{
  prnt_dmnEnumAllPrnt = testPrntDmnEnumAllPrnt.prnt_dmnEnumAllPrnt,
  dmnEnumAllPrntPrnt = testPrntDmnEnumAllPrnt.dmnEnumAllPrntPrnt,
  dmnEnumAllPrnt,
  dmnEnumAllPrntValue,
}

public enum testPrntDmnEnumAllPrnt
{
  prnt_dmnEnumAllPrnt,
  dmnEnumAllPrntPrnt,
}

public class testDmnEnumDescr
  : GqlpDomainEnum
  , ItestDmnEnumDescr
{
}

public enum testEnumDmnEnumDescr
{
  dmnEnumDescr,
}

public class testDmnEnumExcl
  : GqlpDomainEnum
  , ItestDmnEnumExcl
{
}

public enum testEnumDmnEnumExcl
{
  dmnEnumExcl,
  enum_dmnEnumExcl,
  dmnEnumExclValue,
}

public class testDmnEnumExclPrnt
  : GqlpDomainEnum
  , ItestDmnEnumExclPrnt
{
}

public enum testEnumDmnEnumExclPrnt
{
  prnt_dmnEnumExclPrnt = testPrntDmnEnumExclPrnt.prnt_dmnEnumExclPrnt,
  dmnEnumExclPrntPrnt = testPrntDmnEnumExclPrnt.dmnEnumExclPrntPrnt,
  dmnEnumExclPrnt,
  dmnEnumExclPrntValue,
}

public enum testPrntDmnEnumExclPrnt
{
  prnt_dmnEnumExclPrnt,
  dmnEnumExclPrntPrnt,
}

public class testDmnEnumLabel
  : GqlpDomainEnum
  , ItestDmnEnumLabel
{
}

public enum testEnumDmnEnumLabel
{
  dmnEnumLabel,
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

public enum testEnumDmnEnumPrnt
{
  enum_dmnEnumPrnt,
  prnt_dmnEnumPrnt,
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

public enum testEnumDmnEnumPrntDescr
{
  enum_dmnEnumPrntDescr,
  prnt_dmnEnumPrntDescr,
}

public class testDmnEnumUnq
  : GqlpDomainEnum
  , ItestDmnEnumUnq
{
}

public enum testEnumDmnEnumUnq
{
  enum_dmnEnumUnq,
  dmnEnumUnq,
  dmnEnumUnqValue,
}

public enum testDupDmnEnumUnq
{
  dmnEnumUnq,
  dup_dmnEnumUnq,
  dmnEnumUnqDup,
}

public class testDmnEnumUnqPrnt
  : GqlpDomainEnum
  , ItestDmnEnumUnqPrnt
{
}

public enum testEnumDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt = testPrntDmnEnumUnqPrnt.dmnEnumUnqPrnt,
  prnt_dmnEnumUnqPrnt = testPrntDmnEnumUnqPrnt.prnt_dmnEnumUnqPrnt,
  dmnEnumUnqPrntPrnt = testPrntDmnEnumUnqPrnt.dmnEnumUnqPrntPrnt,
  enum_dmnEnumUnqPrnt,
  dmnEnumUnqPrntValue,
}

public enum testPrntDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt,
  prnt_dmnEnumUnqPrnt,
  dmnEnumUnqPrntPrnt,
}

public enum testDupDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt,
  dup_dmnEnumUnqPrnt,
  dmnEnumUnqPrntDup,
}

public class testDmnEnumValue
  : GqlpDomainEnum
  , ItestDmnEnumValue
{
}

public enum testEnumDmnEnumValue
{
  dmnEnumValue,
}

public class testDmnEnumValuePrnt
  : GqlpDomainEnum
  , ItestDmnEnumValuePrnt
{
}

public enum testEnumDmnEnumValuePrnt
{
  prnt_dmnEnumValuePrnt = testPrntDmnEnumValuePrnt.prnt_dmnEnumValuePrnt,
  dmnEnumValuePrnt,
}

public enum testPrntDmnEnumValuePrnt
{
  prnt_dmnEnumValuePrnt,
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

public enum testEnumDescr
{
  enumDescr,
}

public enum testEnumPrnt
{
  prnt_enumPrnt = testPrntEnumPrnt.prnt_enumPrnt,
  enumPrnt,
}

public enum testPrntEnumPrnt
{
  prnt_enumPrnt,
}

public enum testEnumPrntAlias
{
  prnt_enumPrntAlias = testPrntEnumPrntAlias.prnt_enumPrntAlias,
  val_enumPrntAlias,
  prnt_enumPrntAlias,
  enumPrntAlias = prnt_enumPrntAlias,
}

public enum testPrntEnumPrntAlias
{
  prnt_enumPrntAlias,
}

public enum testEnumPrntDescr
{
  prnt_enumPrntDescr = testPrntEnumPrntDescr.prnt_enumPrntDescr,
  enumPrntDescr,
}

public enum testPrntEnumPrntDescr
{
  prnt_enumPrntDescr,
}

public enum testEnumPrntDup
{
  prnt_enumPrntDup = testPrntEnumPrntDup.prnt_enumPrntDup,
  enumPrntDup = testPrntEnumPrntDup.prnt_enumPrntDup,
  enumPrntDup,
}

public enum testPrntEnumPrntDup
{
  prnt_enumPrntDup,
  enumPrntDup = prnt_enumPrntDup,
}

public class testUnionDescr
  : GqlpEncoderBase
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
  : GqlpEncoderBase
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
  : GqlpEncoderBase
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
  : GqlpEncoderBase
  , ItestPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
