//HintName: test_constraint-parent-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public interface ItestCnstPrntEnumInp
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp>? AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; }
  ItestCnstPrntEnumInpObject? As_CnstPrntEnumInp { get; }
}

public interface ItestCnstPrntEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstPrntEnumInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumInpObject<TType>? As_RefCnstPrntEnumInp { get; }
}

public interface ItestRefCnstPrntEnumInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstPrntEnumInp
{
  parentCnstPrntEnumInp = testParentCnstPrntEnumInp.parentCnstPrntEnumInp,
  cnstPrntEnumInp,
}

public enum testParentCnstPrntEnumInp
{
  parentCnstPrntEnumInp,
}
