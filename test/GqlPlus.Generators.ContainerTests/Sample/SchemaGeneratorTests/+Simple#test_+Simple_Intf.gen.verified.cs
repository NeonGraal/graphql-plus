//HintName: test_+Simple_Intf.gen.cs
// Generated from +Simple.graphql+ for Intf
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

public interface ItestDmnEnumAllDescr
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumAllPrnt
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumDescr
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumExcl
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumExclPrnt
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumLabel
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumPrnt
  : ItestPrntDmnEnumPrnt
{
}

public interface ItestPrntDmnEnumPrnt
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumPrntDescr
  : ItestPrntDmnEnumPrntDescr
{
}

public interface ItestPrntDmnEnumPrntDescr
  : IGqlpDomainEnum
{
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
}

public interface ItestDmnEnumValuePrnt
  : IGqlpDomainEnum
{
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
{
  Number AsNumber { get; }
}

public interface ItestUnionPrnt
  : ItestPrntUnionPrnt
{
  String AsString { get; }
}

public interface ItestPrntUnionPrnt
{
  Number AsNumber { get; }
}

public interface ItestUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
  Number AsNumber { get; }
}

public interface ItestPrntUnionPrntDescr
{
  Number AsNumber { get; }
}

public interface ItestUnionPrntDup
  : ItestPrntUnionPrntDup
{
  Number AsNumber { get; }
}

public interface ItestPrntUnionPrntDup
{
  Number AsNumber { get; }
}
