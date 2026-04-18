//HintName: test_constraint-parent-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public interface ItestCnstPrntEnumOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp>? AsParentCnstPrntEnumOutpparentCnstPrntEnumOutp { get; }
  ItestCnstPrntEnumOutpObject? As_CnstPrntEnumOutp { get; }
}

public interface ItestCnstPrntEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstPrntEnumOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumOutpObject<TType>? As_RefCnstPrntEnumOutp { get; }
}

public interface ItestRefCnstPrntEnumOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstPrntEnumOutp
{
  parentCnstPrntEnumOutp = testParentCnstPrntEnumOutp.parentCnstPrntEnumOutp,
  cnstPrntEnumOutp,
}

public enum testParentCnstPrntEnumOutp
{
  parentCnstPrntEnumOutp,
}
