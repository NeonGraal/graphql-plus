//HintName: test_generic-field-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public class testGnrcFieldDualOutp
  : GqlpModelImplementationBase
  , ItestGnrcFieldDualOutp
{
  public ItestGnrcFieldDualOutpObject? As_GnrcFieldDualOutp { get; set; }
}

public class testGnrcFieldDualOutpObject
  : GqlpModelImplementationBase
  , ItestGnrcFieldDualOutpObject
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }

  public testGnrcFieldDualOutpObject
    ( ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldDualOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcFieldDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldDualOutpObject<TRef>? As_RefGnrcFieldDualOutp { get; set; }
}

public class testRefGnrcFieldDualOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcFieldDualOutpObject<TRef>
{

  public testRefGnrcFieldDualOutpObject
    ()
  {
  }
}

public class testAltGnrcFieldDualOutp
  : GqlpModelImplementationBase
  , ItestAltGnrcFieldDualOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldDualOutpObject? As_AltGnrcFieldDualOutp { get; set; }
}

public class testAltGnrcFieldDualOutpObject
  : GqlpModelImplementationBase
  , ItestAltGnrcFieldDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
