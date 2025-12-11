//HintName: test_+Simple_Intf.gen.cs
// Generated from +Simple.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public interface ItestDmnBoolDescr
  : IDomainBoolean
{
}

public interface ItestDmnBoolPrnt
  : ItestPrntDmnBoolPrnt
{
}

public interface ItestPrntDmnBoolPrnt
  : IDomainBoolean
{
}

public interface ItestDmnBoolPrntDescr
  : ItestPrntDmnBoolPrntDescr
{
}

public interface ItestPrntDmnBoolPrntDescr
  : IDomainBoolean
{
}

public interface ItestDmnEnumAll
  : IDomainEnum
{
}

public interface ItestDmnEnumAllDescr
  : IDomainEnum
{
}

public interface ItestDmnEnumAllPrnt
  : IDomainEnum
{
}

public interface ItestDmnEnumDescr
  : IDomainEnum
{
}

public interface ItestDmnEnumLabel
  : IDomainEnum
{
}

public interface ItestDmnEnumPrnt
  : ItestPrntDmnEnumPrnt
{
}

public interface ItestPrntDmnEnumPrnt
  : IDomainEnum
{
}

public interface ItestDmnEnumPrntDescr
  : ItestPrntDmnEnumPrntDescr
{
}

public interface ItestPrntDmnEnumPrntDescr
  : IDomainEnum
{
}

public interface ItestDmnEnumValue
  : IDomainEnum
{
}

public interface ItestDmnEnumValuePrnt
  : IDomainEnum
{
}

public interface ItestDmnNmbrDescr
  : IDomainNumber
{
}

public interface ItestDmnNmbrPrnt
  : ItestPrntDmnNmbrPrnt
{
}

public interface ItestPrntDmnNmbrPrnt
  : IDomainNumber
{
}

public interface ItestDmnNmbrPrntDescr
  : ItestPrntDmnNmbrPrntDescr
{
}

public interface ItestPrntDmnNmbrPrntDescr
  : IDomainNumber
{
}

public interface ItestDmnStrDescr
  : IDomainString
{
}

public interface ItestDmnStrPrnt
  : ItestPrntDmnStrPrnt
{
}

public interface ItestPrntDmnStrPrnt
  : IDomainString
{
}

public interface ItestDmnStrPrntDescr
  : ItestPrntDmnStrPrntDescr
{
}

public interface ItestPrntDmnStrPrntDescr
  : IDomainString
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
