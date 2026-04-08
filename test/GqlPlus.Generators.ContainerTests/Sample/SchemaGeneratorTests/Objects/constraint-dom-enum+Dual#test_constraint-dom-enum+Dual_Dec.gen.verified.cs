//HintName: test_constraint-dom-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public interface ItestCnstDomEnumDual
  // No Base because it's Class
{
  ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual>? AsEnumCnstDomEnumDualcnstDomEnumDual { get; }
  ItestCnstDomEnumDualObject? As_CnstDomEnumDual { get; }
}

public interface ItestCnstDomEnumDualObject
  // No Base because it's Class
{
}

public interface ItestRefCnstDomEnumDual<TType>
  // No Base because it's Class
{
  ItestRefCnstDomEnumDualObject<TType>? As_RefCnstDomEnumDual { get; }
}

public interface ItestRefCnstDomEnumDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumDual
{
  cnstDomEnumDual,
  other,
}

public interface ItestJustCnstDomEnumDual
  : IGqlpDomainEnum
{
}
