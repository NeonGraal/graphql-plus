//HintName: test_constraint-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public interface ItestCnstEnumPrntDual
  // No Base because it's Class
{
  ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual>? AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; }
  ItestCnstEnumPrntDualObject? As_CnstEnumPrntDual { get; }
}

public interface ItestCnstEnumPrntDualObject
  // No Base because it's Class
{
}

public interface ItestRefCnstEnumPrntDual<TType>
  // No Base because it's Class
{
  ItestRefCnstEnumPrntDualObject<TType>? As_RefCnstEnumPrntDual { get; }
}

public interface ItestRefCnstEnumPrntDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntDual
{
  parentCnstEnumPrntDual = testParentCnstEnumPrntDual.parentCnstEnumPrntDual,
  cnstEnumPrntDual,
}

public enum testParentCnstEnumPrntDual
{
  parentCnstEnumPrntDual,
}
