//HintName: test_constraint-parent-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public interface ItestCnstPrntEnumDual
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual>? AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; }
  ItestCnstPrntEnumDualObject? As_CnstPrntEnumDual { get; }
}

public interface ItestCnstPrntEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstPrntEnumDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumDualObject<TType>? As_RefCnstPrntEnumDual { get; }
}

public interface ItestRefCnstPrntEnumDualObject<TType>
  : IGqlpInterfaceBase
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
