using System.Runtime.CompilerServices;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Decoding;

internal abstract class ObjectDecoder<TModel>
  : DecoderBase<TModel>
  where TModel : class
{
  protected delegate IMessages Decoder(IValue input, out TModel? output);
  protected readonly List<Decoder> Decoders = [];

  protected ObjectDecoder()
    => Decoders.Add(DecodeObject);

  public override IMessages Decode(IValue input, out TModel? output)
  {
    IMessages messages = Messages.New;
    foreach (Decoder decoder in Decoders) {
      messages.Add(decoder(input, out output));
      if (output is not null) {
        return messages;
      }

      messages.Convert();
    }

    output = null;
    return messages.Add(TagMsg($"Unable to decode {input}").Error());
  }

  protected virtual IMessages DecodeObject(IValue input, out TModel? output)
  {
    if (input.TryGetMap(out IMap<IValue>? map)
        || input.TryGetList(out IEnumerable<IValue>? list)
          && list.Count() == 1 && list.First().TryGetMap(out map)) {
      return DecodeMap(map, out output);
    }

    output = null;
    return new Messages(TagMsg($"Unable to decode {input}").Error());
  }

  protected void DecodeScalarField<T>(IMessages messages, IDecoder<T> decoder, IMap<IValue> map, out T? value, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
  {
    string fieldName = valueExpr.Split()[1];
    if (map.TryGetValue(fieldName, out IValue? fieldValue)) {
      messages.Add(decoder.Decode(fieldValue, out value));
    } else {
      value = default;
    }
  }

  protected void DecodeClassListField<T>(IMessages messages, IDecoder<T> decoder, IMap<IValue> map, out IEnumerable<T> value, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
    where T : class
  {
    value = [];
    string fieldName = valueExpr.Split()[1];
    if (map.TryGetValue(fieldName, out IValue? fieldValue)) {
      if (fieldValue.TryGetList(out IEnumerable<IValue>? list)) {
        messages.Add(DecodeClassList(list, decoder, out IEnumerable<T>? result));
        if (result?.Count() > 0) {
          value = result;
          return;
        }
      }

      messages.Add(TagMsg($"Unable to decode list field '{fieldName}' with value {fieldValue}").Error());
    }
  }

  protected void DecodeStructListField<T>(IMessages messages, IDecoder<T?> decoder, IMap<IValue> map, out IEnumerable<T> value, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
    where T : struct
  {
    value = [];
    string fieldName = valueExpr.Split()[1];
    if (map.TryGetValue(fieldName, out IValue? fieldValue)) {
      if (fieldValue.TryGetList(out IEnumerable<IValue>? list)) {
        messages.Add(DecodeStructList(list, decoder, out IEnumerable<T>? result));
        if (result?.Count() > 0) {
          value = result;
          return;
        }
      }

      messages.Add(TagMsg($"Unable to decode list field '{fieldName}' with value {fieldValue}").Error());
    }
  }

  protected abstract IMessages DecodeMap(IMap<IValue> map, out TModel? output);
}

internal abstract class FilterModelDecoder<TModel>
  : ObjectDecoder<TModel>
  where TModel : FilterModel
{
  private readonly IDecoder<bool?> _boolean;
  private readonly IDecoder<string> _nameFilter;

  public FilterModelDecoder(IDecoder<bool?> boolean, IDecoder<string> nameFilter)
  {
    _boolean = boolean;
    _nameFilter = nameFilter;

    Decoders.Add(DecodeNames);
  }

  protected abstract IMessages DecodeNames(IValue input, out TModel? output);

  protected IMessages DecodeFilterMap(IMap<IValue> map, out FilterModel? output)
  {
    IMessages messages = Messages.New;

    DecodeClassListField(messages, _nameFilter, map, out IEnumerable<string>? names);
    DecodeScalarField(messages, _boolean, map, out bool? matchAliases);
    DecodeClassListField(messages, _nameFilter, map, out IEnumerable<string>? aliases);
    DecodeScalarField(messages, _boolean, map, out bool? returnByAlias);
    DecodeScalarField(messages, _boolean, map, out bool? returnReferencedTypes);

    output = new([.. names]) {
      MatchAliases = matchAliases ?? true,
      Aliases = [.. aliases],
      ReturnByAlias = returnByAlias ?? false,
      ReturnReferencedTypes = returnReferencedTypes ?? false
    };

    return messages;
  }

  protected IMessages DecodeFilterNames(IValue input, out FilterModel? output)
  {
    IMessages messages = Messages.New;
    output = null;

    if (input.TryGetText(out string? strValue)) {
      output = new FilterModel([strValue]);
    } else if (input.TryGetList(out IEnumerable<IValue>? list)) {
      messages.Add(DecodeClassList(list, _nameFilter, out IEnumerable<string> names));
      if (names.Any()) {
        output = new FilterModel([.. names]);
      }
    }

    return messages;
  }
}

internal class FilterModelDecoder(IDecoder<bool?> boolean, IDecoder<string> nameFilter)
  : FilterModelDecoder<FilterModel>(boolean, nameFilter)
{
  protected override IMessages DecodeMap(IMap<IValue> map, out FilterModel? output)
    => DecodeFilterMap(map, out output);

  protected override IMessages DecodeNames(IValue value, out FilterModel? output)
    => DecodeFilterNames(value, out output);
}

internal class CategoryFilterModelDecoder(
  IDecoder<bool?> boolean,
  IDecoder<string> nameFilter,
  IDecoder<CategoryOption?> resolution
) : FilterModelDecoder<CategoryFilterModel>(boolean, nameFilter)
{
  protected override IMessages DecodeMap(IMap<IValue> map, out CategoryFilterModel? output)
  {
    IMessages messages = DecodeFilterMap(map, out FilterModel? filterModel);
    if (filterModel is null) {
      output = null;
      return messages;
    }

    DecodeStructListField(messages, resolution, map, out IEnumerable<CategoryOption>? resolutions);

    output = new(filterModel) { Resolutions = [.. resolutions], };
    return messages;
  }

  protected override IMessages DecodeNames(IValue value, out CategoryFilterModel? output)
  {
    IMessages messages = DecodeFilterNames(value, out FilterModel? filterModel);

    output = filterModel is null ? null : new(filterModel);
    return messages;
  }
}

internal class TypeFilterModelDecoder(
  IDecoder<bool?> boolean,
  IDecoder<string> nameFilter,
  IDecoder<TypeKindModel?> kind
) : FilterModelDecoder<TypeFilterModel>(boolean, nameFilter)
{
  protected override IMessages DecodeMap(IMap<IValue> map, out TypeFilterModel? output)
  {
    IMessages messages = DecodeFilterMap(map, out FilterModel? filterModel);
    if (filterModel is null) {
      output = null;
      return messages;
    }

    DecodeStructListField(messages, kind, map, out IEnumerable<TypeKindModel>? kinds);

    output = new(filterModel) { Kinds = [.. kinds], };
    return messages;
  }

  protected override IMessages DecodeNames(IValue value, out TypeFilterModel? output)
  {
    IMessages messages = DecodeFilterNames(value, out FilterModel? filterModel);

    output = filterModel is null ? null : new(filterModel);
    return messages;
  }
}
