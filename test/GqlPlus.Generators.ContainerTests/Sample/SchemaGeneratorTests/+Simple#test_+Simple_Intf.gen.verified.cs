//HintName: test_+Simple_Intf.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  new testEnumDmnEnumAll? Value { get; }
}

public interface ItestDmnEnumAllDescr
  : IGqlpDomainEnum
{
  new testEnumDmnEnumAllDescr? Value { get; }
}

public interface ItestDmnEnumAllPrnt
  : IGqlpDomainEnum
{
  new testEnumDmnEnumAllPrnt? Value { get; }
}

public interface ItestDmnEnumDescr
  : IGqlpDomainEnum
{
  new testEnumDmnEnumDescr? Value { get; }
}

public interface ItestDmnEnumExcl
  : IGqlpDomainEnum
{
  new testEnumDmnEnumExcl? Value { get; }
}

public interface ItestDmnEnumExclPrnt
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumLabel
  : IGqlpDomainEnum
{
  new testEnumDmnEnumLabel? Value { get; }
}

public interface ItestDmnEnumPrnt
  : ItestPrntDmnEnumPrnt
{
  new testEnumDmnEnumPrnt? Value { get; }
}

public interface ItestPrntDmnEnumPrnt
  : IGqlpDomainEnum
{
  new testEnumDmnEnumPrnt? Value { get; }
}

public interface ItestDmnEnumPrntDescr
  : ItestPrntDmnEnumPrntDescr
{
  new testEnumDmnEnumPrntDescr? Value { get; }
}

public interface ItestPrntDmnEnumPrntDescr
  : IGqlpDomainEnum
{
  new testEnumDmnEnumPrntDescr? Value { get; }
}

public interface ItestDmnEnumUnq
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumUnqPrnt
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumValue
  : IGqlpDomainEnum
{
  new testEnumDmnEnumValue? Value { get; }
}

public interface ItestDmnEnumValuePrnt
  : IGqlpDomainEnum
{
  new testEnumDmnEnumValuePrnt? Value { get; }
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

public interface ItestUnionDescr
  : IGqlpModelImplementationBase
{
  Number AsNumber { get; }
}

public interface ItestUnionPrnt
  : ItestPrntUnionPrnt
{
  String AsString { get; }
}

public interface ItestPrntUnionPrnt
  : IGqlpModelImplementationBase
{
  Number AsNumber { get; }
}

public interface ItestUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
  Number AsNumber { get; }
}

public interface ItestPrntUnionPrntDescr
  : IGqlpModelImplementationBase
{
  Number AsNumber { get; }
}

public interface ItestUnionPrntDup
  : ItestPrntUnionPrntDup
{
  Number AsNumber { get; }
}

public interface ItestPrntUnionPrntDup
  : IGqlpModelImplementationBase
{
  Number AsNumber { get; }
}
