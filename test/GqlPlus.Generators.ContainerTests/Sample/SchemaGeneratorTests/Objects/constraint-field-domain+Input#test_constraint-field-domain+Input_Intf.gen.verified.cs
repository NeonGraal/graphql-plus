//HintName: test_constraint-field-domain+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public interface ItestCnstFieldDmnInp
  : ItestRefCnstFieldDmnInp<ItestDomCnstFieldDmnInp>
{
  ItestCnstFieldDmnInpObject AsCnstFieldDmnInp { get; }
}

public interface ItestCnstFieldDmnInpObject
  : ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>
{
}

public interface ItestRefCnstFieldDmnInp<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldDmnInpObject<TRef> AsRefCnstFieldDmnInp { get; }
}

public interface ItestRefCnstFieldDmnInpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnInp
  : IGqlpDomainString
{
}
