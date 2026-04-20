//HintName: test_parent-alt+Dual_Model.gen.cs
// Generated from {CurrentDirectory}parent-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public class testPrntAltDual
  : testRefPrntAltDual
  , ItestPrntAltDual
{
  public decimal? AsNumber { get; set; }
  public ItestPrntAltDualObject? As_PrntAltDual { get; set; }
}

public class testPrntAltDualObject
  : testRefPrntAltDualObject
  , ItestPrntAltDualObject
{

  public testPrntAltDualObject
    ( decimal pparent
    ) : base(pparent)
  {
  }
}

public class testRefPrntAltDual
  : GqlpModelBase
  , ItestRefPrntAltDual
{
  public string? AsString { get; set; }
  public ItestRefPrntAltDualObject? As_RefPrntAltDual { get; set; }
}

public class testRefPrntAltDualObject
  : GqlpModelBase
  , ItestRefPrntAltDualObject
{
  public decimal Parent { get; set; }

  public testRefPrntAltDualObject
    ( decimal pparent
    )
  {
    Parent = pparent;
  }
}
