﻿namespace GqlPlus.Resolving;

public class TypeOutputResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel, OutputArgModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverAlternateTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeOutputResolver(dual);
  }

  protected override OutputAlternateModel MakeAlternate(string alternate)
    => new(alternate, "");
  protected override OutputBaseModel MakeBase(string name, string description = "", params OutputArgModel[] args)
    => new(name, description) { Args = args };
  protected override OutputAlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(alternate, "") { Collections = [collection] };
  protected override OutputAlternateModel MakeParamAlternate(string alternate)
    => new(alternate, "") { IsTypeParam = true };
  protected override TypeOutputModel NewModel(string name, string description)
    => new(name, description);
  protected override OutputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override OutputArgModel NewArg(string argument, bool isParam = false)
    => new(argument, "") { IsTypeParam = isParam };
}
