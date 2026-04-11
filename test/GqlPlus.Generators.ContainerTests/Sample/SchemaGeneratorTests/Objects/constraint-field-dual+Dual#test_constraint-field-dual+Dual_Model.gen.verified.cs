//HintName: test_constraint-field-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public class testCnstFieldDualDual
  : testRefCnstFieldDualDual<ItestAltCnstFieldDualDual>
  , ItestCnstFieldDualDual
{
  public ItestCnstFieldDualDualObject? As_CnstFieldDualDual { get; set; }
}

public class testCnstFieldDualDualObject
  : testRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>
  , ItestCnstFieldDualDualObject
{

  public testCnstFieldDualDualObject
    ( ItestAltCnstFieldDualDual field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldDualDual<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDualDual<TRef>
{
  public ItestRefCnstFieldDualDualObject<TRef>? As_RefCnstFieldDualDual { get; set; }
}

public class testRefCnstFieldDualDualObject<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDualDualObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDualDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testPrntCnstFieldDualDual
  : GqlpModelBase
  , ItestPrntCnstFieldDualDual
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldDualDualObject? As_PrntCnstFieldDualDual { get; set; }
}

public class testPrntCnstFieldDualDualObject
  : GqlpModelBase
  , ItestPrntCnstFieldDualDualObject
{

  public testPrntCnstFieldDualDualObject
    ()
  {
  }
}

public class testAltCnstFieldDualDual
  : testPrntCnstFieldDualDual
  , ItestAltCnstFieldDualDual
{
  public ItestAltCnstFieldDualDualObject? As_AltCnstFieldDualDual { get; set; }
}

public class testAltCnstFieldDualDualObject
  : testPrntCnstFieldDualDualObject
  , ItestAltCnstFieldDualDualObject
{
  public decimal Alt { get; set; }

  public testAltCnstFieldDualDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
