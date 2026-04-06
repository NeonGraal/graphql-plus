//HintName: test_constraint-enum-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public interface ItestCnstEnumPrntInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp>? AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; }
  ItestCnstEnumPrntInpObject? As_CnstEnumPrntInp { get; }
}

public interface ItestCnstEnumPrntInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstEnumPrntInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntInpObject<TType>? As_RefCnstEnumPrntInp { get; }
}

public interface ItestRefCnstEnumPrntInpObject<TType>
  : IGqlpModelImplementationBase
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
