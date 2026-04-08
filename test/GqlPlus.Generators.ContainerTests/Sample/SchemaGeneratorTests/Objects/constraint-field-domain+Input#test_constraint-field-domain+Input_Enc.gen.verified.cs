//HintName: test_constraint-field-domain+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public class testCnstFieldDmnInp
  : testRefCnstFieldDmnInp<ItestDomCnstFieldDmnInp>
  , ItestCnstFieldDmnInp
{
  public ItestCnstFieldDmnInpObject? As_CnstFieldDmnInp { get; set; }
}

public class testCnstFieldDmnInpObject
  : testRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>
  , ItestCnstFieldDmnInpObject
{

  public testCnstFieldDmnInpObject
    ( ItestDomCnstFieldDmnInp field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldDmnInp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstFieldDmnInp<TRef>
{
  public ItestRefCnstFieldDmnInpObject<TRef>? As_RefCnstFieldDmnInp { get; set; }
}

public class testRefCnstFieldDmnInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstFieldDmnInpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDmnInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testDomCnstFieldDmnInp
  : GqlpDomainString
  , ItestDomCnstFieldDmnInp
{
}
