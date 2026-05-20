//HintName: test_operation-selection-mods_Model.gen.cs
// Generated from {CurrentDirectory}operation-selection-mods.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_mods;

public class testCatOprSelectionMods
  : GqlpModelBase
  , ItestCatOprSelectionMods
{
  public ItestCatOprSelectionModsObject? As_CatOprSelectionMods { get; set; }
}

public class testCatOprSelectionModsObject
  : GqlpModelBase
  , ItestCatOprSelectionModsObject
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprSelectionMods Address { get; set; }

  public testCatOprSelectionModsObject
    ( string pfirst
    , string plast
    , ItestAddrOprSelectionMods paddress
    )
  {
    First = pfirst;
    Last = plast;
    Address = paddress;
  }
}

public class testAddrOprSelectionMods
  : GqlpModelBase
  , ItestAddrOprSelectionMods
{
  public ItestAddrOprSelectionModsObject? As_AddrOprSelectionMods { get; set; }
}

public class testAddrOprSelectionModsObject
  : GqlpModelBase
  , ItestAddrOprSelectionModsObject
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public testAddrOprSelectionModsObject
    ( string pstreet
    , string pcity
    , string pcountry
    )
  {
    Street = pstreet;
    City = pcity;
    Country = pcountry;
  }
}
