//HintName: test_constraint-alt-domain+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public interface ItestCnstAltDmnInp
  // No Base because it's Class
{
  ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp>? AsRefCnstAltDmnInp { get; }
  ItestCnstAltDmnInpObject? As_CnstAltDmnInp { get; }
}

public interface ItestCnstAltDmnInpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltDmnInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnInpObject<TRef>? As_RefCnstAltDmnInp { get; }
}

public interface ItestRefCnstAltDmnInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestDomCnstAltDmnInp
  : IGqlpDomainString
{
}
