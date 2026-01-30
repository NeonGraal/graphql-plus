namespace GqlPlus.Resolving.Simple;

internal class TypeDomainEnumResolver
  : ResolverChildType<BaseDomainModel<DomainLabelModel>, TypeRefModel<SimpleKindModel>>
{
  protected override string? ParentName(BaseDomainModel<DomainLabelModel> model)
    => model.Parent?.Name;

  public override BaseDomainModel<DomainLabelModel> Resolve(BaseDomainModel<DomainLabelModel> model, IResolveContext context)
  {
    model = base.Resolve(model, context);

    Map<DomainLabel> allItems = [];
    AllItems(allItems, model, context);

    model.AllItems = [.. allItems.Values.OrderBy(v => v.Order).Select(v => v.ToItem)];

    return model;
  }

  private void AllItems(Map<DomainLabel> allItems, BaseDomainModel<DomainLabelModel> model, IResolveContext context)
  {
    if (model.ParentModel is BaseDomainModel<DomainLabelModel> parent) {
      AllItems(allItems, parent, context);
    }

    Map<string> excludes = ExcludeItems(model);
    RemoveExcludesFromAllItems(allItems, excludes);

    foreach (DomainLabel label in AllLabels(allItems, model, context)) {
      AddItem(label, allItems, excludes);
    }
  }

  private IEnumerable<DomainLabel> AllLabels(Map<DomainLabel> allItems, BaseDomainModel<DomainLabelModel> model, IResolveContext context)
  {
    int index = allItems.Count > 0 ? allItems.Max(v => v.Value.Order) : -1;
    return model.Items
        .Where(i => !i.Exclude)
        .SelectMany(i => ItemLabels(i, model.Name, ref index, context));
  }

  private static Map<string> ExcludeItems(BaseDomainModel<DomainLabelModel> model)
    => model.Items
        .Where(i => i.Exclude)
        .ToMap(k => k.EnumValue.Label, v => v.EnumValue.Name);

  private List<DomainLabel> ItemLabels(
    DomainLabelModel item,
    string domainName,
    ref int index,
    IResolveContext context)
  {
    List<DomainLabel> labels = [];
    if (item.EnumValue.Label == GqlpDomainLabelConstants.All) {
      foreach (EnumValueModel enumLabel in AllLabels(item.EnumValue.Name, context)) {
        labels.Add(DomainLabel.FromLabel(domainName, enumLabel, item, ++index));
      }
    } else {
      labels.Add(DomainLabel.FromItem(domainName, item, ++index));
    }

    return labels;
  }

  private static void AddItem(DomainLabel newItem, Map<DomainLabel> allItems, Map<string> excludes)
  {
    if (allItems.ContainsKey(newItem.Label)) {
      return;
    }

    if (excludes.TryGetValue(newItem.Label, out string? excludeEnumType)
        && (string.IsNullOrWhiteSpace(excludeEnumType) || newItem.EnumType == excludeEnumType)) {
      return;
    }

    allItems.Add(newItem.Label, newItem);
  }

  private static void RemoveExcludesFromAllItems(Map<DomainLabel> allItems, Map<string> excludes)
  {
    foreach (MapPair<string> exclude in excludes
        .Where(e =>
          allItems.TryGetValue(e.Key, out DomainLabel existingItem) &&
          (string.IsNullOrWhiteSpace(e.Value) || existingItem.EnumType == e.Value))) {
      allItems.Remove(exclude.Key);
    }
  }

  private EnumValueModel[] AllLabels(string? enumName, IResolveContext context)
  {
    List<EnumValueModel> labels = [];
    if (context.TryGetType("", enumName, out TypeEnumModel? enumType)) {
      labels.AddRange(AllLabels(enumType.Parent?.Name, context));

      IEnumerable<EnumValueModel> unique = enumType.Items
        .Where(i => !labels.Any(l => l.Label == i.Name))
        .Select(i => new EnumValueModel(enumName, i.Name, i.Description));
      labels.AddRange(unique);
    }

    return [.. labels];
  }

  private record struct DomainLabel(
    string Domain,
    string Label,
    int Order,
    bool Excluded,
    string EnumType,
    string LabelDescription,
    string ItemDescription
  )
  {
    internal static DomainLabel FromLabel(
      string domain,
      EnumValueModel enumLabel,
      DomainLabelModel item,
      int index
    ) => new(domain,
      enumLabel.Label,
      index,
      item.Exclude,
      enumLabel.Name,
      enumLabel.Description,
      item.Description);
    internal static DomainLabel FromItem(string domain, DomainLabelModel item, int index)
      => new(domain,
      item.EnumValue.Label,
      index,
      item.Exclude,
      item.EnumValue.Name,
      item.EnumValue.Description,
      item.Description);

    internal readonly DomainItemModel<DomainLabelModel> ToItem
      => new(
        new(
          new(EnumType, Label, LabelDescription),
          Excluded,
          ItemDescription),
        Domain);
  }
}
