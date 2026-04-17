//HintName: test_+Simple_Intf.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public interface ItestDmnBoolDescr
  : IGqlpDomainBoolean
{
}

public interface ItestDmnBoolPrnt
  : ItestPrntDmnBoolPrnt
{
}

public interface ItestPrntDmnBoolPrnt
  : IGqlpDomainBoolean
{
}

public interface ItestDmnBoolPrntDescr
  : ItestPrntDmnBoolPrntDescr
{
}

public interface ItestPrntDmnBoolPrntDescr
  : IGqlpDomainBoolean
{
}

public interface ItestDmnEnumAll
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumAll
{
  dmnEnumAll,
  enum_dmnEnumAll,
  dmnEnumAllValue,
}

public interface ItestDmnEnumAllDescr
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumAllDescr
{
  dmnEnumAllDescr,
  enum_dmnEnumAllDescr,
  dmnEnumAllDescrValue,
}

public interface ItestDmnEnumAllPrnt
  : IGqlpDomainEnum
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

public interface ItestDmnEnumDescr
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumDescr
{
  dmnEnumDescr,
}

public interface ItestDmnEnumExcl
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumExcl
{
  dmnEnumExcl,
  enum_dmnEnumExcl,
  dmnEnumExclValue,
}

public interface ItestDmnEnumExclPrnt
  : IGqlpDomainEnum
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

public interface ItestDmnEnumLabel
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumLabel
{
  dmnEnumLabel,
}

public interface ItestDmnEnumPrnt
  : ItestPrntDmnEnumPrnt
{
}

public interface ItestPrntDmnEnumPrnt
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumPrnt
{
  enum_dmnEnumPrnt,
  prnt_dmnEnumPrnt,
}

public interface ItestDmnEnumPrntDescr
  : ItestPrntDmnEnumPrntDescr
{
}

public interface ItestPrntDmnEnumPrntDescr
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumPrntDescr
{
  enum_dmnEnumPrntDescr,
  prnt_dmnEnumPrntDescr,
}

public interface ItestDmnEnumUnq
  : IGqlpDomainEnum
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

public interface ItestDmnEnumUnqPrnt
  : IGqlpDomainEnum
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

public interface ItestDmnEnumValue
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumValue
{
  dmnEnumValue,
}

public interface ItestDmnEnumValuePrnt
  : IGqlpDomainEnum
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

public interface ItestDmnNmbrDescr
  : IGqlpDomainNumber
{
}

public interface ItestDmnNmbrPrnt
  : ItestPrntDmnNmbrPrnt
{
}

public interface ItestPrntDmnNmbrPrnt
  : IGqlpDomainNumber
{
}

public interface ItestDmnNmbrPrntDescr
  : ItestPrntDmnNmbrPrntDescr
{
}

public interface ItestPrntDmnNmbrPrntDescr
  : IGqlpDomainNumber
{
}

public interface ItestDmnNmbrPstv
  : IGqlpDomainNumber
{
}

public interface ItestDmnNmbrRange
  : IGqlpDomainNumber
{
}

public interface ItestDmnStrDescr
  : IGqlpDomainString
{
}

public interface ItestDmnStrNonEmpty
  : IGqlpDomainString
{
}

public interface ItestDmnStrPrnt
  : ItestPrntDmnStrPrnt
{
}

public interface ItestPrntDmnStrPrnt
  : IGqlpDomainString
{
}

public interface ItestDmnStrPrntDescr
  : ItestPrntDmnStrPrntDescr
{
}

public interface ItestPrntDmnStrPrntDescr
  : IGqlpDomainString
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

public interface ItestUnionDescr
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface ItestUnionPrnt
  : ItestPrntUnionPrnt
{
}

public interface ItestPrntUnionPrnt
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface ItestUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
}

public interface ItestPrntUnionPrntDescr
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface ItestUnionPrntDup
  : ItestPrntUnionPrntDup
{
}

public interface ItestPrntUnionPrntDup
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}
