//HintName: test_constraint-enum-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public interface ItestCnstEnumPrntInp
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp>? AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; }
  ItestCnstEnumPrntInpObject? As_CnstEnumPrntInp { get; }
}

public interface ItestCnstEnumPrntInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumPrntInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntInpObject<TType>? As_RefCnstEnumPrntInp { get; }
}

public interface ItestRefCnstEnumPrntInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntInp
{
  parentCnstEnumPrntInp = testParentCnstEnumPrntInp.parentCnstEnumPrntInp,
  cnstEnumPrntInp,
}

public enum testParentCnstEnumPrntInp
{
  parentCnstEnumPrntInp,
}
