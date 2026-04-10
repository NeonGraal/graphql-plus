//HintName: test_generic-parent-string-dom+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public interface ItestGnrcPrntStrDomInp
  : ItestFieldGnrcPrntStrDomInp<ItestDomGnrcPrntStrDomInp>
{
  ItestGnrcPrntStrDomInpObject? As_GnrcPrntStrDomInp { get; }
}

public interface ItestGnrcPrntStrDomInpObject
  : ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>
{
}

public interface ItestFieldGnrcPrntStrDomInp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntStrDomInpObject<TRef>? As_FieldGnrcPrntStrDomInp { get; }
}

public interface ItestFieldGnrcPrntStrDomInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomInp
  : IGqlpDomainString
{
}
