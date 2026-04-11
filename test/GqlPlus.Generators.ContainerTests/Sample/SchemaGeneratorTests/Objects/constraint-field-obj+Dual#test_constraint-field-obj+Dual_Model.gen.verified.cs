//HintName: test_constraint-field-obj+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public class testCnstFieldObjDual
  : testRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
  , ItestCnstFieldObjDual
{
  public ItestCnstFieldObjDualObject? As_CnstFieldObjDual { get; set; }
}

public class testCnstFieldObjDualObject
  : testRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>
  , ItestCnstFieldObjDualObject
{

  public testCnstFieldObjDualObject
    ( ItestAltCnstFieldObjDual field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldObjDual<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldObjDual<TRef>
{
  public ItestRefCnstFieldObjDualObject<TRef>? As_RefCnstFieldObjDual { get; set; }
}

public class testRefCnstFieldObjDualObject<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldObjDualObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldObjDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testPrntCnstFieldObjDual
  : GqlpModelBase
  , ItestPrntCnstFieldObjDual
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldObjDualObject? As_PrntCnstFieldObjDual { get; set; }
}

public class testPrntCnstFieldObjDualObject
  : GqlpModelBase
  , ItestPrntCnstFieldObjDualObject
{

  public testPrntCnstFieldObjDualObject
    ()
  {
  }
}

public class testAltCnstFieldObjDual
  : testPrntCnstFieldObjDual
  , ItestAltCnstFieldObjDual
{
  public ItestAltCnstFieldObjDualObject? As_AltCnstFieldObjDual { get; set; }
}

public class testAltCnstFieldObjDualObject
  : testPrntCnstFieldObjDualObject
  , ItestAltCnstFieldObjDualObject
{
  public decimal Alt { get; set; }

  public testAltCnstFieldObjDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
