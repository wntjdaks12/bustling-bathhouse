using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniHUDObject : UIObject
{
    [SerializeField] private TextMeshProUGUI text_nickname;

    [SerializeField] private Image img_currentHp;

    [SerializeField] 
    private float offsetY;

    public override void Init(Entity entity)
    {
        base.Init(entity);
    }

    private void LateUpdate()
    {/*
        if (target != null)
        {
            var statAbility = target.HeroObject.Hero?.StatAbility;
            if (statAbility != null)
            {
                img_currentHp.fillAmount = statAbility.CurrentHp / statAbility.MaxHp;
            }

            var scrPos = Camera.main.WorldToScreenPoint(target.HeroObject.MiniHUDNode.transform.position); scrPos.y += offsetY;
            RectTransform.anchoredPosition = scrPos;
        }*/
    }
}
