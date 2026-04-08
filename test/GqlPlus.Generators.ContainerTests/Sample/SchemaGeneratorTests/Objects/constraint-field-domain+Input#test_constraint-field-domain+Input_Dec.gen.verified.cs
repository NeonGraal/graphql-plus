//HintName: test_constraint-field-domain+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  // No Base because it's Class
{
  ItestRefCnstFieldDmnInpObject<TRef>? As_RefCnstFieldDmnInp { get; }
}

public interface ItestRefCnstFieldDmnInpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnInp
  : IGqlpDomainString
{
}
