//HintName: test_constraint-parent-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public interface ItestCnstPrntEnumDual
  : IGqlpModelImplementationBase
{
  ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual> AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; }
  ItestCnstPrntEnumDualObject AsCnstPrntEnumDual { get; }
}

public interface ItestCnstPrntEnumDualObject
{
}

public interface ItestRefCnstPrntEnumDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstPrntEnumDualObject<TType> AsRefCnstPrntEnumDual { get; }
}

public interface ItestRefCnstPrntEnumDualObject<TType>
{
  TType Field { get; }
}
