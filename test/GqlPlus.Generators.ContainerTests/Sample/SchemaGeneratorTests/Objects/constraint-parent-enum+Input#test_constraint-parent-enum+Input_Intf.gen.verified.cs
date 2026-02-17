//HintName: test_constraint-parent-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public interface ItestCnstPrntEnumInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp> AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; }
  ItestCnstPrntEnumInpObject AsCnstPrntEnumInp { get; }
}

public interface ItestCnstPrntEnumInpObject
{
}

public interface ItestRefCnstPrntEnumInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstPrntEnumInpObject<TType> AsRefCnstPrntEnumInp { get; }
}

public interface ItestRefCnstPrntEnumInpObject<TType>
{
  TType Field { get; }
}
