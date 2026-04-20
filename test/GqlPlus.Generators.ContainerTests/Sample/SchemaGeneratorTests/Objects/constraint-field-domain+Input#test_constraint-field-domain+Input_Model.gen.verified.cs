//HintName: test_constraint-field-domain+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
    ( ItestDomCnstFieldDmnInp pfield
    ) : base(pfield)
  {
  }
}

public class testRefCnstFieldDmnInp<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDmnInp<TRef>
{
  public ItestRefCnstFieldDmnInpObject<TRef>? As_RefCnstFieldDmnInp { get; set; }
}

public class testRefCnstFieldDmnInpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDmnInpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDmnInpObject
    ( TRef pfield
    )
  {
    Field = pfield;
  }
}

public class testDomCnstFieldDmnInp
  : GqlpDomainString
  , ItestDomCnstFieldDmnInp
{
}
