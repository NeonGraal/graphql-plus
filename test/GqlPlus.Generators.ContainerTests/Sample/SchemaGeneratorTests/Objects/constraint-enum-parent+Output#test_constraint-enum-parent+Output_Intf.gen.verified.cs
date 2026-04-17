//HintName: test_constraint-enum-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public interface ItestCnstEnumPrntOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp>? AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; }
  ItestCnstEnumPrntOutpObject? As_CnstEnumPrntOutp { get; }
}

public interface ItestCnstEnumPrntOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumPrntOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntOutpObject<TType>? As_RefCnstEnumPrntOutp { get; }
}

public interface ItestRefCnstEnumPrntOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntOutp
{
  parentCnstEnumPrntOutp = testParentCnstEnumPrntOutp.parentCnstEnumPrntOutp,
  cnstEnumPrntOutp,
}

public enum testParentCnstEnumPrntOutp
{
  parentCnstEnumPrntOutp,
}
