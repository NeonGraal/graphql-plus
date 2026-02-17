//HintName: test_constraint-field-obj+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public class testCnstFieldObjOutp
  : testRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
  , ItestCnstFieldObjOutp
{
  public ItestCnstFieldObjOutpObject? As_CnstFieldObjOutp { get; set; }
}

public class testCnstFieldObjOutpObject
  : testRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>
  , ItestCnstFieldObjOutpObject
{

  public testCnstFieldObjOutpObject(TRef field)
    : base(field)
  {
  }
}

public class testRefCnstFieldObjOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstFieldObjOutp<TRef>
{
  public ItestRefCnstFieldObjOutpObject<TRef>? As_RefCnstFieldObjOutp { get; set; }
}

public class testRefCnstFieldObjOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstFieldObjOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldObjOutpObject(TRef field)
  {
    Field = field;
  }
}

public class testPrntCnstFieldObjOutp
  : GqlpModelImplementationBase
  , ItestPrntCnstFieldObjOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldObjOutpObject? As_PrntCnstFieldObjOutp { get; set; }
}

public class testPrntCnstFieldObjOutpObject
  : GqlpModelImplementationBase
  , ItestPrntCnstFieldObjOutpObject
{

  public testPrntCnstFieldObjOutpObject()
  {
  }
}

public class testAltCnstFieldObjOutp
  : testPrntCnstFieldObjOutp
  , ItestAltCnstFieldObjOutp
{
  public ItestAltCnstFieldObjOutpObject? As_AltCnstFieldObjOutp { get; set; }
}

public class testAltCnstFieldObjOutpObject
  : testPrntCnstFieldObjOutpObject
  , ItestAltCnstFieldObjOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstFieldObjOutpObject(decimal alt)
  {
    Alt = alt;
  }
}
