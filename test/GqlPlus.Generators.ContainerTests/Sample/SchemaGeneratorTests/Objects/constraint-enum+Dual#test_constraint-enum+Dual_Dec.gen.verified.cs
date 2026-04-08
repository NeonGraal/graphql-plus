//HintName: test_constraint-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public interface ItestCnstEnumDual
  // No Base because it's Class
{
  ItestRefCnstEnumDual<testEnumCnstEnumDual>? AsEnumCnstEnumDualcnstEnumDual { get; }
  ItestCnstEnumDualObject? As_CnstEnumDual { get; }
}

public interface ItestCnstEnumDualObject
  // No Base because it's Class
{
}

public interface ItestRefCnstEnumDual<TType>
  // No Base because it's Class
{
  ItestRefCnstEnumDualObject<TType>? As_RefCnstEnumDual { get; }
}

public interface ItestRefCnstEnumDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstEnumDual
{
  cnstEnumDual,
}
