public class RangeCondition : BaseCondition
{
    private readonly Tag<float> _tag;
    private readonly float _min;
    private readonly float _max;

    public RangeCondition(string id, Tag<float> tag, float min, float max) : base(id)
    {
        _tag = tag;
        _min = min;
        _max = max;
    }

    protected override bool CheckCondition()
    {
        return _tag.Value >= _min && _tag.Value <= _max;
    }
}