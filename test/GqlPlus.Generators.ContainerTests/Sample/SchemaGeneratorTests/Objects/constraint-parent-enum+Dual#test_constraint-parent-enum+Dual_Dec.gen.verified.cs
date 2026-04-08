//HintName: test_constraint-parent-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public interface ItestCnstPrntEnumDual
  // No Base because it's Class
{
  ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual>? AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; }
  ItestCnstPrntEnumDualObject? As_CnstPrntEnumDual { get; }
}

public interface ItestCnstPrntEnumDualObject
  // No Base because it's Class
{
}

public interface ItestRefCnstPrntEnumDual<TType>
  // No Base because it's Class
{
  ItestRefCnstPrntEnumDualObject<TType>? As_RefCnstPrntEnumDual { get; }
}

public interface ItestRefCnstPrntEnumDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstPrntEnumDual
{
  parentCnstPrntEnumDual = testParentCnstPrntEnumDual.parentCnstPrntEnumDual,
  cnstPrntEnumDual,
}

public enum testParentCnstPrntEnumDual
{
  parentCnstPrntEnumDual,
}
