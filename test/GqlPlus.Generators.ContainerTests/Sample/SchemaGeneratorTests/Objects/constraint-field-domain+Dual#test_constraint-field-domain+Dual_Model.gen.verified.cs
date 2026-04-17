//HintName: test_constraint-field-domain+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public class testCnstFieldDmnDual
  : testRefCnstFieldDmnDual<ItestDomCnstFieldDmnDual>
  , ItestCnstFieldDmnDual
{
  public ItestCnstFieldDmnDualObject? As_CnstFieldDmnDual { get; set; }
}

public class testCnstFieldDmnDualObject
  : testRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>
  , ItestCnstFieldDmnDualObject
{

  public testCnstFieldDmnDualObject
    ( ItestDomCnstFieldDmnDual field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldDmnDual<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDmnDual<TRef>
{
  public ItestRefCnstFieldDmnDualObject<TRef>? As_RefCnstFieldDmnDual { get; set; }
}

public class testRefCnstFieldDmnDualObject<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDmnDualObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDmnDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testDomCnstFieldDmnDual
  : GqlpDomainString
  , ItestDomCnstFieldDmnDual
{
}
