//HintName: test_constraint-field-domain+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public interface ItestCnstFieldDmnInp
  : ItestRefCnstFieldDmnInp<ItestDomCnstFieldDmnInp>
{
  ItestCnstFieldDmnInpObject? As_CnstFieldDmnInp { get; }
}

public interface ItestCnstFieldDmnInpObject
  : ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>
{
}

public interface ItestRefCnstFieldDmnInp<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDmnInpObject<TRef>? As_RefCnstFieldDmnInp { get; }
}

public interface ItestRefCnstFieldDmnInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnInp
  : IGqlpDomainString
{
}
