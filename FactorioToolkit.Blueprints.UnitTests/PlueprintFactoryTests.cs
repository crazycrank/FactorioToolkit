using System.Collections.Generic;
using System.Threading.Tasks;

using FactorioToolkit.Domain.Items;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

namespace FactorioToolkit.Blueprints.UnitTests
{
    [TestClass]
    public class PlueprintFactoryTests
    {
        private const string BlueprintString = "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";
        private const string BlueprintBookString = "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";
        private const string BlueprintWithRails = "0eNqlveuOHceVbf0u+m02Mu4R/SofDg5kmXAToGRBlhtfo+F3P5Rdu1gS16oaI+uXYcOcNTNuK3bGyBn/+92fP//j48+/fPrp1+/+83+/+/TD3376+3f/+f/973d///TXn77//Nv/9uv//Pzxu//87tOvH3/87k/f/fT9j7/9t1++//T5u3/+6btPP/3l4///3X+Wf/7J/pPq/0kD/+TPn/764ePnjz/8+sunHz78/LfPH1/8+/7P//On7z7+9OunXz99/PdT/uu//M///ekfP/754y9fHuNZ5u+/fvnbf/2vXz/8y8Kfvvv5b3//8q/+9tNvf/eL0odS//Td//zrP+s/f3P1B6GKhfqrOu2rzo/ff/784fP3P/78rcj1H+OhUv5jRDqd+nndzqAybzTP/F0Pf/jhv77/9NOHp44N2ro9P1858fOtGx13RUJbORtvGjt+IIS+yvXKCP92QLyuVfRoiHXq7xsra6avrVS/jNQv0/Evn375Yv9f/4ce6TY/zGKDnRl8McCgw+HHW9mhxakHSCK00FLx4etaUXY8ZMu2wyNxdHQ3xkL1utHaM1QqvrVjoarbKNbxQz0R6jfaqIdKw7dRLDR1G8U6y7dRLPR1YP/wj1/+++Nf0hZqTzrX+f1aMCLVc6Pl42J/+ZaPhfQCn+hU1mBpe0VrZ7sx5GN3d4Z8WCfajSEfC/khH+vcGPKx0GYV8EP5WqSv9ccSWCLlG8P+Cpf3fsFp+WxwvD0ru1/pE3dwDmTmoinQmx0mibeuh0kiNMy299Wx0iJ5vsn5bT/0b+X+e90V6a4buhP43TfGdliWu9//x0Lj0kMm1il+yMRCeAeUNn00b0fzsv3t1WqIWrEfuvXtETjGDd3+9ggct38hXy3e1Y8bP5GvcBs1th/TsdCBC//z9qK8vbZOWE0yzWhQTr2fih94Vj/5YqGm1us/jI6325DXlWxQh804vGx9e25PXl3q48XIdb09t+e6oVvfntvzTnWJX6MdtUqcr8OgkC3e4r9HtmjXVbwsaNbl37nGrbr87izWwbMoe8xoEq2hVS/Q1arevDaQwq7xP2eSJsVTJ52RYZseLwsadfP5U5+e++y3588uWvYbu1Ev7XpjXYpfojeudIkH7/T9TXkSXW/Xuj20V9aa/sVu0phLL0exDp476XNGc2fDTVzWJ5HmuazVPw6faDqeGz99wpY8eKKk8y986mZl0VPzXz71aQCd+fZcPMPL7rdnzZl6DUJu/Y+fE74oOfuO0NuPrV8TxPa+jDO1I6yPQn6+eY+zQnk8hS7eOV9KtFXdb8+mLz913qnaQtX+zhYooap6//ZKr8UtYd9KZ4NLb+NYR+0bsqGQPnBEnVNwNcpWuvCx+Sl8ti7Hbvkurj69QTvgVWvhh/JfdcGr1kLP6F+cUJxBfr0Wc0jfTUtMr4taYt2pfaHSTYrlzIQIKL4+xc7EUX4VXSLO9avoEX7Kn6iGE5+f+SdNEI72ahGvrIdUKfr90Hmbm+FMwBtDXEAB3fSNmjml548fD6ijXZO+5+BAtjSHjcExgqySxG5FhXp6h3XAUUxpzeuCo5hiOINp/A6vi/ze+A0VnjIUjiF8SBo0Hldby1YyrnyRIt3UNZWTtKZHElB39+qOCp+XrIZ+PHR31JSrx42rqxYZYH141VBH/3Ai45RTC2b148yCWfu6/0kVNyXnF7K1LuxpgTNM0UUcbqhm4eNwQzULn4Ab2uOtBDinKwJueNYFB3VlTA1NML/L6yK/N1761XgW3DywPRWtppOXqmQ2hMOW4w/PsqS7OA2RyYazYbb3NkI4CDgT8WJ3EQoN903PST7pKfNGdQp18LRRvbutKhqK552qYd9y0MEMxBecgzlT/3auhy2xNEuUdD/HHbJFM/anGSLWqLgmZSUpdju1LHLLK1J76qUNDsIL5yCedc9FJsLRyBPya0iIS/jd5SYmuU/27ZOHIE787ZmAILZpyq5/PKOW1J9AHHCkXTwFkbXmskIbHI6XF1AE/6wys3hkPUb9fSz4nbg7xeu8PWw4CrHFqOEkxBZ9ffTXEllTjnv07WHflnIGIlsr40ZdVpa1Ki5FWSWK3R4rS9zWixei9pilAGGoHIz4qgtwg3pVzfoxv83rIr/+m7ydfPPruTz25NProidfaiuynnciiOGo175R/0KhY49KN6AZatEHuxvQDPUlJIG+at/JR+212LNcNJqKPctFY6l0v5MIdVShemVIxs8+LaXJRtLSsmgkacooa9RjMU302JyMqGYCcTIiq0ux26plkVteltrTq5gN+JAq0hGedQEgUqunYJnf6XWRX48YMb/+DflOcjXOHaW3n9xnKyQGW7lH2O6BFtVmWdgNSI7aLAuLer31d6qGawDHIi7T//MWYfttr8Xta7/RyAaXL1Ko+88N2TBk5tJCpMu7RmHRY/eqZZFbPJmyWhK77VoWuRWHuI+3KYA3qCLT4VkXEAdVZDo8qDPmd3td5PdoGhj5HZfXJX5HubMFCJXqPcp49+QnGscjPvTXnXX9YxR1ydCyqEem/Q0JWJPKYYikCcLVZNhsuKyHzi3K+F9D5803qHXeKVOhULG8LuobkQPRRedw8iFb4WK3Xcsit/wkdxu3U8sit+L86bEvBZhEFWEQz7oAaajzaBga+RWZEHULvyIU4kHyMb/V6yK/zZfROCl4abCIPbg+0M38zRtCoAHXPWx5F/SLbO1b2PK36nHj6qNeAKHUfXnVUMce9W7AstStgaPMno74Yq3XtSx67GGZXeZ2alnklr+IuIzbrWWRW/HFxtOYWoCZqOfSuhvQDvUUDUQzv1XrMr9NA9HMr0/TY36HqwnPn9/tCxWFG+kSO0RAqgiUmKZht5Vl7XpubDHCgOLLV5ZQp0jgdgNmpHFYIumTMOf20nnF2UPTNPpXhvUKhXWuHmvOaWVZey6L2jK328oyt3ynV4VbjktkhS90W8Qnhk8zdAHMoYlQiWddADo0ESrxwLyY3+51kd+hOWbm10dYMr/rJh+9VvyOthV/0rt2rHQsyIyasurQStSS/uaI5LH1zRGZjmVkF+A6WrWZlQtgHa3qe4Oyh573yNu1yHvjVjUiyxpVp1ayVtWILHLLSYlsSQ7dijspunFbtSxyK46iHptJgEw0kSXxrAvwhiayJB5AFvM7vS7yuzR/zPxur4v8eixpzfjSkkvzx+jJRbpEucSTy3iJZ4h0IXKm/TFe4u3j45WEVLWuX6RnXWTjIzKdeeuQc6EopdbXLbh3IQ6tdZ0Wuybp7qNlAeTShj7wTbqM0xHZ8hE+9tCJseyxm6VwmduuZZFbPq2mcTu1LHIrDnwfe2EAkTRze8aO/Ybr9DgacUZ+RaZEm8KvCJV40HnMb/W6yK8/8GV+/RdTq8d3j407SuDJ9QFwZtBSspmOpmQXIEfaPDdkw8vbfDUCCEpbmpJFj700JcvcakqWudWULHPLa9M2bqeWRW55bRqPbRRgRpqIlXjWBaxHE7ESDygL+RWxEm0Lv+aGjWn8+mxm5rdpVpj57V4X+R13ammo5GtTIqRrU6Kzb6z9oZCOil2A5Gjiao1kpMSXgeqoWOa2alnktllGlLntWha5xbMlW5Rjt1PLIreiNj3NgAnQiCbQiIfuAmxEM2zExf12kTTRL+63i6SJBznG/PpUZua3aQCX+fWpzMzvjdp0xdca+9qUCOnalOj42pQIHYtarotc2awzYieAIrq4aGMbtzojlrltFrVkbruVZW55barG7bSyzK2oTU9TaQLmoAso4lkXQAe9eD4W+a2ej0V+q+djmV/PxzK/no9lfj0fy/ze5WPnJodx/Y94BQCFZpK3029ETcz4bvqqo48yIfvVRqLT9Pu9TKhYIvTbjgwHYKv3OJlv5XsoryNjJ2A5etORsROwHL3pyFjmVkfGMrfLkqHM7dayyC2eUlnhC91ySCKr06FbwUiMxw4TsBedB0181QXsRe9NY7fMb/e6yO/Q2C3zO70u8utveGd+t9dFfj2FNEPOoQ8dh5QJ2W8NMx39dWEm1CxsOQFl0DkTkY2UcEXiTEQ2sGO3U8sit8vClszt1rLILa9NU7jlQERWQ0K3gocYj90P4Au64CGedQEV0KcnZJlfT8gyv56QZX49Icv8ekKW+fWELPN7ozaF+ERfvjYlQro2JTq+NiVC+ob3CSiDzpmIbKSEK5K4aqMbt1PLIrfLYoDM7dayyC2vTVu45UBEVkNCt4KHmI/dD+ALuuAhnnUBX9AFD/Hgbpjf7nWR36EZS+Z3el3kd7FU7vp8qdFMLrHqe2tckz368brk0UW0RPm62IZK+ovCTKi6C8XSvuBYxBuG9EUbmdCwaOIE5EMXF2wkQy5cJQ+bFWBSiDs1pnnuo2XBcw8RCrG528FBh2wNj93ykIjLuG1aFrnlFWc+zaUB6IkhKIeH7gT0xBDMw4MqYn498cr8bk2QMr+eeEV+XyISr1Xe9pxoNpKbzsYLLAJcffX1YPWK1TzaihpSJETUaRrSf3aRPbkO2suE5o27yDItiwxlOpudUD5/vDjRHVej6G8tEoPi2oxkeITLedU86wAAyngBMoAufmPKvaQXXlkLwFJQNbjKGlEnvLJG1OAqc7usLHPL78Gtxu2xssituCZjPq0cAxAxoxWvC4iY0aqmgpnf5nWR366pYOZ3eF3kd2oqmPldXhf59fFEI2RzRtOZeYlQv+QVZiNBqka377MzR/p9dibULAI7AP0xOJ6QjblwbROxDpdxO7UscrssAsvcbi2L3PJy1IVbjilk1Sh0K+7AmI/tHeA+xqheF3AfQ1yM8eChmN/udZHfofli5nd6XeR3ab6Y+d1eF/n1Z60jpGXG1GetmZCuTYmOr02JULN45gD0x+B4QjZSwhWJ0wnZwI7dTi2L3C6LZzK3W8sit7w2TeGWYwpZDQndiosw5mP3A7iPIS7CeNYF3McQF2E8eCjmt3td5Hdo9pX5nV4X+V2afWV+t9dFfm/UppCWGdvXpkRI16ZEx9emRKhZPHMA+mNwPCEbKeGKxOmEbGDHbqeWRW6XxTOZ261lkVtem7ZwyymFrIaEbgWysB67HwBrDHH/xbMugDWGuP/iwUMxv93rIr9Ds6/M7/S6yO/S7Cvzu70u8nujNoVkyrx8bUqEdG1KdHxtSoR0puQAfMS8dKbkAHzEvHSmJHOrMyWZ22XxTOZ2a1nkFs+WbFEO3fKUh6yGhG7F1RfraQZ0ACBMATY8dAcAEKYAGx7EEPPbtS7zOzT7yvxOrcv8Ls2+Mr9b6zK/N2pTyAXM6mtTIqRrU6Lja1MipDMlBzhLn1VnSnZwlj6rzpRkbnWmJHO7LMDI3G4ry9zy2lSFW44/ZDUkdCvoh/U0lTo4RZ+CfnjWBafoU9APD7qE+fU0K/M7NB3K/Hqalfldmg5lfj3Nyvz62tRDYmB2XZsyIVubMh1dmzIhnSnZwQn47BrN6+AEfHadKcncajSPuV0WdmNuNZrH3PLa1IVbzkJkNSR0K1iI9dj9gLPvKViIZ11w9j0FC/FgQpjf7nWR36FJQuZ3el3kd2mSkPndXhf5vVGbQmJgehYiE9K1KdHxtSkR0pmSHZyAz6kzJTs4AZ9TZ0oytzpTkrldFlFjbreWRW55bZrCLWchshoSuhUsxHrsfsDZ9xQsxLMuOPuegoV4MCHMb/e6yO/Q/B/zO70u8rs0/8f8bq+L/B6Yp9n2A/7unSR1zu0/Q+8hizC3/gw9E7IX22Y6+r71TKhb+K130vQa1evgbH1yHCKbMrFbjeoxt9vCb8ytRvWQW45DZMt96JbjEFl1it3y6rQf+ypwqj4FDfGsC07Vp6AhHrQJ8zu8LvI7NVnI/C6vi/xuTRYyv8frAr/rulGbQhZhXb42JUK6NiU6vjYlQt3Cbx2cra9Lo3odnK0vjkNkAzt2q1E95nZb+I251agecstxiGxRDt1yHCKrIbFbUZueZkADp+pL0BAP3Q5O1ZegIR60CfM7tC7zOzVZyPwurcv8bk0WMr9H6yK/9UZtClmEVX1tSoR0bUp0fG1KhLqF3zo4W19Vo3oNnK0vkQaxjVuN6jG328JvzK1G9ZBbjkNki3LoluMQWQ2J3Yra9DSVGjhVX4KGeNYFp+pL0BAP2oT5HV4X+Z2aLGR+l9dFfv1N68zv8brEb/e1qYUswuq6NmVCtjZlOro2ZUKdvVHtzzfmNHRjzuoa1mvg0H51Des1cGi/uob1mFsN6zG3GtZDboeG9ZBbDkRkq33stmpZ5FYUp8e2ChzXL4FDPOuC4/olcIgHxsL8Tq+L/C6NLDK/2+siv0cji8ivgCPGJfyKay/K13YIlaoueomQjUHOdHQMciakYb0GDu3X1LBeA4f2a2pYj7nVsB5zq2E95HZpWA+55UBEtijHbquWRW5FbXrsfsBx/RI4xLMuOK5fAod4YCzM7/S6yO/SyCLzu70u8ns0soj8ChhiVOF336hNIYqwtq9NiZCuTYmOr02JkIb1GjhaX1vDeg0cra+tYT3mVsN6zK2G9ZDbo2E95JbTENmiHLutWha55bXpPHY/4FB9CRjiWZccqgsY4gGbML/T6yK/SyOLzO/2usjvYSmt4/n2jpbc3rEF//Bgrsijb0FDjM4ffV/V3uaTP3rzFbPGSl1XzERouNtx8mebtvQmhpYuvYnQlvfN5I+mb3FugEHYRd/i3ACDsF+iDa88N5ipnGbI1pL4uZuWRc/dLW7I3A4ti9zi6ZLVwdjt0rLILS8r52lWVsAxbMExPHQb4Bi24BgefA/yK6iGfRm/Pn2S+W1al/ntrCbO58s1anK5xn7BPZB7dubXZg3VPLzKGtLDq6wht72wKG/Ic+vCoqQh243T1kTJn7YmQvXGBUCZln5RkOj4FwWJ0Lhz9U0mNuXVN+mgappBbQBx2U3HRVaAuOympsAbSwm8mAIscZw3yBbhsBE5fZDVjLAROYyQlbjYbbeyzC3enmUbiNjttLLMLS8j52nhqYC52X17XcDcbI4mPHPHyO+4vC7xO3wCK/PrE1iZX5/Ayvz6BFbmd+hdQQ1JpW3uqnhdaMn7g2pyf9DmzMEbjvTlfYnQ1NeVV4DabM4UZGMuXNs4YJBNkdht07LIbbeQLXM7tCxyy8tRN26XlkVuRTV6bO8AZLPn8boAstnr0gQz8ivyGXY3fn3mKvPbvC7y6zNXmd/hdZHf6atciCZtk8jwupCuTYmOr02xEIcKsqYPVyTOFGQjJVyROGCQDezYbdOyyG23LCxzO7Qscstr0zRul5ZFbkVteux+AGSz9/G6ALLZ59KgMfIr7qrY0/j1mavMb/O6yK/PXGV+h9dFfm/UphBN2sfXpkRI16ZEx9emUOhwwiBr+hHKFi0LUJvDwxeygR27bVoWue2WhWVuh5ZFbnlt2sbt0rLIrbid+XpsfwAac65zQxiwMadcGjVGhsVtFXsbvz51lfltXhf59amrzO/wusjvjeoU0jun+OqUCOnqlOj46hQLVX1pcwXkx+FoQjZSwjWJkwnZwI7dNi2L3HZLwzK3Q8sit3i2pKtybHd5XeTX1KenSVAAXXHq8cIV4BVHUAwPHgoZFkzDuYxfn7zK/Daty/z65FXmd2hd5vdGfQrpgNN8fUqEdH1KdHx9ioW6vri5ghP1IyCIZKSEaxKHILKBHbttVpa57RbPZG6HlWVuRX2qxu7SusyvqU9Ps6mA4/TTzw1hcJ5+BAfx4EyQYcFBnGr8+uxV5tdnrzK/PnuV+fXZq8yvr08lZAfO0PUpE7L1KdPR9SkRmvry5gLOws/UkF4BZ+GHUxHZwI7dakiPue0We2NuNaTH3Ir61I3d5XWR369T6Yd//PLfH/+SF5HzJNt+L1tD2T/E6P/wX99/+ikP0y/XeqBQZfwx/Cn0LfiIcs24QcLlTgASDwClADDgCEDidOPXx7Ayv93rIr8+hpX5nV4X+V2+/IV4wjFXVrwudGz5i3U4L/HGk3FCImv6cM3bmt4r4Lj9cEIiG9ixW03vMbfD8nDMrab3mNvFwv7OyNf7cBpyRiJd7uN2OKz+peUvXIxeEBKvNsOrdS9shxeMxOv305T6TBeX9kfpsGa/wCRYzW72DzTNSpZKWrsr42c+++5oryG4iWffnfTldL51hy7NerL23l4XtQe9e2lfeQ9Gs7xc16Waei3X1F/+QNGcKmnrL8IerCWN/UW4wdaeW7e2m5Av/gBt7UFXwa6l3aQs7XeNE0ve2EL2RGq7cayf3v1u0x1X3Dwcbzdu0Z/yZm1bVP279KM39ehev9tfBVk7wMk18mWhx8JqavmxtYy8nhoc2nhrEhdY5/6wtoAWrmp6+cWxFqP/WuGIi12trGV8xagaiy+dlDpOd2Rlv8S6Qw1mPZqrm4uX7sllwX7Y3lvrsvZWhW8f296c+sh+QsTtwamP7CdV3B5NFUP9W/DLP1DlsBTf4l3supK5mSibL44vpSzO2spWymIPWqZSFifcpStlccRdVA+aezuK6kFxj0e5VA9yquTFiQdTbjdQAqbcb9B5THl4fBwqT/3VVLlISXyBmLx+1Pbbe5t/yRbyO777r8dgQ5x3C8eODWGiBvK4cXbHhKtnV5iwz7SFwj5wHQoP/ZEemx6CM9luVKx3CyfjeL/7/Wri2EfcMOHpMwihcPGQMBP2X8dAYf/xJhvHs3th5ni8Wzgex3O++9114nj5M3kmvD3rxoSPh8eRsOBVphoVgleZqvMEsDJV5y0fMAWFuw7EhMJDx3hD4amvwYDCS9/9BIX9DY1Q2F8fzITFVSNddZ64a6SrzjNXj6jO4+TLh6Y6j7MvH5rrPD7zmus8PvOa6zw+85rrPD7zqus8PvOq6jyRE1JV54mgEPdmTySFuBd7An1x7/VEVoh7rSegF/dW70ZaSKnxQdpZd6SIR/PVjhIWv+yEbhEXmEyl60/X474qV72hRBzymVWVLp5Yl5LF08q5tTedQNnlZWMhft2W8oenk5pNPEJEzf7CWRW1XBUeIfLGilp4aIha9AuHU1SVKjw0pLgRgOdTdSMAT6jqRgCeX9X1G55gamtYeOCI2ssWnjiiNt+FR46oXwuFYynq503hWEpz/YbnW3P9xuuX6zdewFy/8S9QXb/xT3tUv3H8RL21KRw/Ua+ZCg8dUe/FCg8dUS/yCodNhuu3YXPRoe60mbZQV98kDnX1da1Q9+gEEKTb/QfhTNd/acd063sxxkRXJz4WkCb1Rbe/VzfxO7QuSKn6ojttthj0u3QmDNPd+lt+pnv0R5JIlyMl6iS+cKIkQwfi8cuBEsU6FM6TZHBGPH6HDrGDfn1KENPVdyVBXX07BdSFMQwZGjZj1fNeODh2yzGSDAyLZwWnSBTJVjhEkhF98azgDIljEAtnSBw2WThD4kjPYnJP3FgTwSduUPDvedxbPs6QOGq5cIbEgdaFMySODS+cIXE4e+EMiSPwyxKXZ7rOG/Lr+uc7HA/5SP3LH5ieiAa5l1+E1w3UGiRfflH2VwRu1BTuK9ZT06aOfW8fMY5aevuIcdbQ21OUzLDPGIeGuz/ZveIjDYGQ9DeU9CFbJrT0eU2mtPXvyovsxDgTkoyXeGJyIiQb37FdDoQk8zGxqz6Ce2UZSeSb/TGBJuXpflfKWnloYdbM031rWORyfRbOuHsSJh8YlnMjenwjv0d/bQIiBL9shHyyK4gQ/KLrk8dBoOkX3ap1SfvWyyUx7OePqxeKP6lX1x9DsPYYWpe1h4s8WcO2x7oZqZLcivtFcd9UXKni0RuOHSvdjThJH7aUe4LpsxaNYmWP2uSGKNNReUG/a7G3QzFqGbfUF1Sfdi+XNYKaJb+fJMTnvidPm0H95HplCYmXPs6LJCtfvDJxXCRZqOOCWNW+8ZX6kjRGsy/NWWPooGVUtap+xc/aWL/hR7Ww+nsAWONumjMZb0GTtj0+DXKg+IzarpuhilTfXwfQSZO0+t7NaNyB4rqaZHrEA07ElDz8djI/mnvfuLvtv6k/JWb9t7Qua2eZnKfHM52K087EfumwQ6pc9KZ3xpuXXu/lElKj7V4sIZXvdkOcNcO4FSFIbc57CYJU3sL+WSPsWzF/1OW5lfIH1YeORE8aYZR7SXzUJwzK08vY0Jd4oOop+BFT5Iaab7rGCYrElDgBkZgKx+NIkg1K0nXHyqKum2p/qbeXs9yMl6P61afLdSTcfLgcE+4+W44JDx8tx4SnT5ZjwssHyzHh7XPlmPDxsXJI+M49Oky4+FA5JlzxaU75t2wjq+dq/jSH+e0en2DCQ+ezMd2p49mY7tK0B0nIrzcoEub3vFc3Hmn7eu+bj9jvLu99k5DoVk2lkOjaKuCRbcbv9tF3JBK3bp98x/xOHSPHdJdOkUPzTQSRbDV+z3t14/l2rve+qYr9Hp95x3Q9rMV0feId0+06Po7p+pvimO7U4XFMd+nsOKa7dXQc0z06OY7oNpNFchndonPjmG7VsXFMt+nUOKbbdWgc0x06M47pTh0Zx3SXToxjulsHxjHdo/PikG65dFwc0y06LY7pVh0Wx3Sbzopjul1HxTHdoZPimO7UQXFMd+mcOKa7dUwc0z06JQ7p1kuHxDHdojPimG7VEXFMt+mEOKbr2f/4oqVWxw0l4nDqeDimu2w6HJPdNhyOyR57app0U7u8EPAnCBPT+RwwMV3P8RLl1d4Jl/XQ0DrE3ZShcEx1yUw4prptJByTPfa8Oemhfnkh4I8TImqJ53EjqiLxtBFVQDkeouo9zxpR2xMeNaJ2U5wOUZs/HjSi9qo8Z0RtrTkeon4J8JQR9cOFh4yo31kcEVE/Czkion7F8oQR9aOboyHqHQFHQ9QrDY6GqDcwHA1RL4x4vIh6v8XTRdTrOE6CqLeHnANRLzs5BaLezXIGRL1K5gTIVF22bOobk9029I3JHpv5hmQ5+WFObRrnPswhU+NJIuZMrHHqwxzhtfVe3DGRHTY9jRzENw58bDUSlpUlx/Bt6RuAmdtjk9OQ7NaJB+QMvm0deMDc1nfKtli2vZOjTdz2d5KpieywsQxolnHMw1BKbetEOjTLOORx1HQ4NokNyb5APN74ui5GAmesWnTeBXNb9TeGTLfpcDem23W2G9MdOtqN6U6d7MZ0lw52Y7pb57ox3aNj3Yhuvy6d6sZ0iw51Y7pVZ7oxXfdV2nn+GKmi3JouQI+n1ZKkVnbBeTyt7eTe0355bLiiVnDpIec5uaCgdJIucI8d+050XQjdHnJ0COzjaSOMulFQH3vyQSegj93F6Cjyy9AiR0fxh9Hx1Tq96By6TOjFRPvx+8+fP3z+/sefX/m6tCQ5ML3YDz4zQ9uePWVCasq80pfx0K46JBxN9GozwtE85NRGPLvjaVjVdHllTUrku/0RjSZ5VZ95vlIBkqae9rcOGxdLyrIe3PIXFBttaua9spOJTb8kPF5Zsr4soc9z+spWrRdYx58//fXDx89f/vQvn3748PPfPn985SPJK1Gr0Fl5fKieG2vyw7RGNpkmHyQcRvHgbOOde8t4pja9Caxo/CzWSwcMn62Gz3l99Bzma785ePplt13kPWHv793Nxd3c6zv3nvGg7M3KotHzkt94rZfm26PnBbNBRs98dfR0tpH7MN4ePXB+NPCEbn60158Qzo/65hOO62biY65Y7inmgtX+VEhabbR7gY+5s35LMNezP2WyB4UT4O1R+4KbAKP21TH7kpV4xVR5s5GO+3WV2HE5Gb8bC2/HNnYXk/FyYBBxey1t1gTtXnQltdlvyVP1gYbT8wqYj/EXMAQY468vzJMVjPbmKJ9stgzweMc83uuVdbHfG/PNx+M0Q7whiXdl652/7eNN2Wrvew8R78mW/UmPtmSLzYr99rBZala8vp1fbFact4eNPT1lw+a876d/3MGcUDjiF8ILQAGdyDbSAJv9WP/6Wz0fNi+QBDBs3niJsNkPjK9vN3Jb496RUmVvs0XUxAnXs0T25hFNYScdWwe8kASybvImdiQbD9KjLwdC70BPuXecBEeGCJ14orXQyDg3j2fgyBDRE0+u0cg4+rvB5EBDRE30V3Xg7/vrRfPFQtv9KMn82M+WYp3BSYK4+1asWm4dIxX0LntwmiCeKC1WvXcwU9EJx7js9a1kcg8OEsTrZ9K+lpNjY2LdOkKiY2JLz2xM3DuUgWNC8AMPLIZQMaMUHWDJdKvOr2S6TcdXMt2u0yuZ7tDhlUx36uxKprt0dCXT3fJWL7KjGOXoPEzktl46DpPpFh1byXSrTq1kus2eOzJZfUrKZMc7f3kkstMmQBLCfIj4iGOGwra5kuRemFH1LXfkXpghwiSOGLetvFM2Xm5afedv0MRts8e+TLbb81kmO975Ky6R1TeUoFnmLyhhbreVZdPh2JBK5FbgCksMMIErLDHABK6wxAATuMISI0HcRjJNlw0bT8lkp02nZLLLhlMy2W2zKZnssdGUSJbHTTySKZlsscGUTLbaXEom22wsJZPtNpWSyQ4bSslkp82kZLLLRlIy2W0TKZnssYGUSJbHTTzyKJlssXGUTLbaNEom22wYJZPtNouSyQ4bRclkp02iZLLLBlEy2W1zKJnssTGUSNZcNCK6zFwzIrpsaZYvzmUb5loR0ffqUhEhO2QAJVOdMn+SqS55tpb10NY6xN2R4ZNIlbMaotN5loRxWt1BY9I5u1kZ4q273EkmOlzsJBOdMnWSqS55ept1ztY6xN2RkZNIlVMZpvqIhAjR65zFMHWdp0OYTQgnMMyOiQMYZnvHaQyzF+WpEGbjzEENs8vn3Ib4STI5xSF+P02eBiF+7E1Ob4hfppNf9SF+Rk9ObXTTW0NGTDLVKRMmmeqSAZNMdct8SaZ6ZLwkUuWUhngDODmjIV5XTk5oiHerk/MZ4kXw5HTGNL01ZLAkU50yV5KpLhkryVS3TJVkqkeGSiJVzmSIM6zJiQxx4DZFHAQ/g5/V3vbNvPb3qbZYdbyPFU28TvkpDlNd8qMZprrfx1smqkeGM5JT8skxDEFhTE5hHH5GPjmEEYMo8dziDIaAcWbr71ON51Yb72NuE682V4WpLvkVFFPdNuuRyR4b9YhkO867DNHHGYsWGx/JvFabHslkmw2PZLLdZkcy2WGjI5nstMmRTHbZ4Egmu21uJJM9NjYSyY7LpkYyWRk7Uc4T1j/+A81ik0LxtORsUiRlKMWZ0na3NOgmRVjgGHFtj+ulwDHijUi8aRI4xpMs67rtPsLrsus0YogaQ2AZT7KoMf6YeJE2w5Ij+AWYgSa2bOWpD5LnP2MhFwazpE33AfOW6vZ7yqwN1NdglzTppptVl7EySQssFSsju2mpGidH2LKpMlkLNLYQ2Im6OtOdsuOXmll29eKMRrzYxuWXMxpxZYir71ITzJazZd+HoJYQKRuV18j9zvchcftu+z4EFd6tNpB2/7i7/aHNum3ARaLK2byn/r5uoxGxtG65UPfRzy1/Ow//TbWQX0Mig+PpzdMmI9hncKDGtRkcj8q2UJrFPPpjMNZ1p9mPdVhryI3kkK0xrGvYGvNe7uNKMjXmWfcEdyq47VZ/J0LnVu5j9qTrum7p7VSvyO38TnQkbJjJtDthiAvlAK6r3xHfUHzIPXHWAvNWFCJtgnVLnbbBlqe5hSSjLxfCkS9y4WK0ij2CJuVvFXs7HGuKot5w5NUvaYomTbOm6PJki5S+9YLzeHUzlOyFkuad9ggKdtuyuqxl3WuOcj1ylg7Kp1kiiePEozjuO5HE8dAlkZarus3hqVlzJLar/aQfNoeOCoDN0e2n3NDv0LrM77SbrhKnQa5qP0xJhWRYW6pj09oyIQ51JE0fz/RmrwwuJIJ0cawjGdiJWxuzC92q/WG+eiSmh4QmYFtMK8vawm0U88oSLyFt6+SzPzZHjYWPjj5jwiJu43F0DoWLDj+DwlWnn0HhpuPPoHDHeWLn37KNjOU+dKwa9Dt1rhoUXjoCDQpvnYEGhY9mHpjwuPzbVCZc3rsJTXSrzUErJOpziRCOY4bE0LlthYSIrqGD26BfndwGdTX5AXW3fqXMdM97fzXEulNfasrGrwjj2GY8TH0RFhu/gvbYZpyJPI5txpkI5FhmnAngY6lxtt77KzLR3TZpDI7f817d2K9I5XjoovErYjmWGWcil2OacSZiOqYZZyKnY5pxJoI6phoP0+ajQd1lA9Kg7rYJaVD32Ig0prsvm5EGdYsNSYO61aakQd1mY9Kgbrc5aVB32KA0qDttUhrUXTYqDepum5UGdY8NS2O6AgRppt9OsXFpULfavDSo22xgGtTtNjEN6g4bmQZ1p81Mg7rLhqZB3W1T06DusbFpSHdflz5Fia+G2Ve5oUQcVpucBnWbjE6Dsl1mp0FZe4Nr2k3TCxF/S8anQdnt8tOg6nEBakyVoyGmYTka8nq/i6wP4665EDWo2mWKGpS10BWUnV42FloySA362zJJDcoeGaXGZDntYer95iEfZnuyOeRhdlObMx5m87c54lFVlw0ZqAZlp0xUg7JLRqpB2S0z1aDskaFqTJaDIeZX7OZgiPnRvTkYYt4RbA6GmFcamyd+dNVlQ0arQdkps9Wg7JLhalB2y3Q1KHtkvBqT5RSIeTe7OQNiXiVvToCYN9+b8x/mRf3muR9TddmQIWtQdsqUtUIuydyc/FhqJOx3yrZY9ryTRozdDovkQ1kbCwdlbS4clG0ybA3Kdpm2xsYtpz22GgnznbLxuB3rnVxq4tamw0FZ+zk0k532e2goW+TnHlC2yiQzNm455WGgqs0hj0Q2HrfzvQxx4tZ/9sJ0l/0iHOpuG5MGdY/NSWO6C2fFxVjrjFWLjV+DbqvNX4O6zQawQd1uE9ig7rARbFB32gw2qLtsCBvU3TaFDeqemzFsv32WSibIvjxFTdJK95YBclezzqtmZ0kk7BbMx0OXNYjLIdi6J/X1tLA9ptZl7eHyCPYjueS3oCOyD9juw8+1bHsfzQ6i9hYsyEMXtbdMBZlbtvepMLHuqzJs6QMjsL5mVvzLc6zV78XfYa9D8wA9cTpvBeBho+tWAh6W37DPxttdduzZfdyix+WCXO6Jz1Vu5elheRkekjbCrfSQbxeBHqv3O3l9uA3GncA+rK5PtLMmXjKyDzvct5JJcOcdGAmYl4aw9JyiJp6tD4fDIknBXLFstbIkxP4UNQHttuQUmOv4yn4q6UR7sQVs5WllWSur8nbsaszpkuQ3QtIYx8qixqjXrUzDb0fGiOWL+w5e/tI7VUfzs9auzaYmYsed7liv5/k9UETCEcEizy/2JurF6YVJouapsBx+OMO2xdafubKmOFoXtUS79GeNyG8rWpf59Z+xMb9N6zK/Xf/4ilOXT9PgcSY05bY907GX4aZC2xIEJIH2cJYkGSlx5eIsSTKwY7ecJUnmYeLWJhJDt/aKJui26xMiZndoXebXpT6+UlnjVUkFisT9lwhvLVxJRuwRgSLnEoZFnsiTLvMr4kTWNn6r1YV+/efWzG+3utCvf/kYJ6yeob+XyYSWrH+Zjr3EPRU6EsyrJL3ycFAkGSnxmjctjgXdVkt5MbdNQjjQbbdsD3M7LHkB7U5NdDC/PjO/kqzKM7cXJmGVR8SB7C0ML52bz/yaOJBp/Faty/w2G9sB/eo4EOhX16caR3yeZetTKiTrU6pj61MqdCSPXkkE5uGcRzJS4jWJB3okAztxW60sc2uzu6HbbmWZ22GJQ2hXk4zQ77JhgZWESh0R5vHQJeFPZ+twOObX3OoyhV8R5rG68Vu1LvPbbPgT9Nu1LvPrq1P8SfM5ujplQrY6ZTq6OmVCR36EVQFhXi+ex5GMlBbL2sRu6LZaWebWJnZDt93KMrcWs4dubVQ3dLtsgGsFsN4X3a11Aaz3RffYwE7mt+jgUua3FBvQCP1Wrcv8NhsgCP12rcv8+toUwklflHRtyoRsbcp0dG3KhI787rhOsiJV+zlz7WRF4tEcycBO3FYry9w2+Y0hdGs/tIRuh/yyDLqdVpa5XfaDgzrJWmToiCfdTdYiQUfsKvwaOqIKv02H/EK/Vesyv82G0EK/Xesyv742zXgFb7o2ZUK2NmU6ujZlQjZqo26yInE8Ihkp8YrULVAL3VqgFrq1IQDQbbeyzO2QiCd0O60sc7ssCVc3WYu6JvfaRdYiQUTsS/gdmtxjfgURMbfxq8k96LfZIHPot1td6NfXph2v4JqISIVeTKkfv//8+cPn73/8Of/8qCbXEn8RkvfupYbsvXuZEGcgkj6MlzbOQCRDLl7aOAORzJDEbZOy0G2XxCJ0O6QsdDslsQjdLikL3W6Lu7WLLGpT43mtkkXN3Iayhd+l8Tzot1rcDfrVeB7029EK/WE+LnSsJ1ujXxAPf/701w8fP3/5y798+uHDz3/7/DF/J9iuRG3a6z5gQy6tyxpys4ZsoCGPasj2ekNunf+eKhW5LUiFqnnANx6vuZ1BqtPlziAVUtPgrc6baFSBQbVtXGerpExxYCGZpXGZ2moKvLGUvIQUXmlEsMRxLCFZhONG5FRCUjPiRuRQQlLiErfdyjK3Q5Kv0O20ssztslhmq6Q8HX07ZOukPIlgiTW53yJuF3noEr9F3DUyu/FbtS7z21j5H4+oo9+W7H/GUt1eSAYffWhd9uisRn2o4NGX3qvURGnbvUomdNjTXW8+nL09JHPE+YM32uglcPDKo4F+44hBMrJWLNutLAFkykvA4JXnBlOVAwbJYpI897Ky7Lm3JI2h22NlkVvOIiSFMHbLWYSkbiduqwVhG4FsSm1al0A2hdMIDxAW+h1al/mdFoSFfpfWZX63vf0T+j1aF/lt/i1BjCaVpt8SZEIyBSzVabZeZkJd3s/RCGpT9LUfjaA2hQMGycBO3C4ry9xuyRlDt/ZCAuZWRDVM4VZENUzjtloQthHIpvSmdQlkU3q3ICz0O7Qu86tv6IZ+l9Zlfre9QRr6PVoX+R2+NsVoUhm6NmVCtjZlOro2ZUL2SqpGUJvCmYJkpMQrEgcMkoGduF1Wlrm1l+VAt8fKIrecTEgW5dgtJxOSGpK4rRaEbQSyKbNZ3U4gmzK7BWGh32F1od9pQVjod1ld6FfUpmn8HqvL/K4LBv71RwBu2yRj/Iuyvm27xaxSEUxCf13InrVmOvqsNRMa8n7HTtibwtmDZAwmPbokwQzdbikL3R5JMDO3HEdI1s/YLWcTkuU+cVulLHTbLGLbCdxSOMTwrEvgliLu25jb+J1al/ldFrGFfrfWZX5FderCr4hneOgiv0fXph6zGeXY2pQKydqU6tjalAoNeaVxJzxD4TxDMlLiFYnzDMnATtza23yhW5vAitxWEc2wudt62QRW6NbeMwrdNkvGdoIfVIE1PHQJflAF1jCn8Tu1LvOrAVTod2td5lfUpir8iniGhy7yW3xtivmIWnRtyoRsbcp0dG3KhHhtips+XpE4DpGMlHhFKhZdhW4tugrd2tBV5rba0FXmttrQVejWhq5Ct83Shp2cqldDQzzpklP1KmiI2Y3fqXWZ32URQeh3a13mV9SmS/gVNMRDF/ltvjbFLEJtujZlQrY2ZTq6NmVCg71RbY+rszq61OmLMK9OcZ/GS53IX4iHYLzUcSAimTGJ22NlkdtuI1eZWw5EJMtn4tZGrkK3zcoytxrV6+S4vnaN6nVyXF+7RvWgX43qQb8a1YN+NarH/Aocom3hV8ARD13mt+qiF0MOVSQy9NeFuix6mc6wRS8TwnMmafp4ReJARDJS4hWJAxHJwE7cHiuL3E4buMrcciAiWeUStzZwFbptVpa51aheJ8f1dWpUb5Dj+jo1qgf9alQP+tWoHvSrUT3mV8Q1tCn8ChjiSRf69bUpRhHq0rUpE7K1KdPRtSkT4rUpbvp4ReI0RDJS4hWJ0xDJwE7cHinL3G4buMrcchoiWeUStzZwFbptUha61ajeIIfqdWtUb5BD9bo1qgf9alQP+tWoHvSrUT3mV8AQrQu/AoZ46DK/ujaNGEWox9amVEjWplTH1qZUiNemuOnjFYnTEMlIiVckTkMkAztxe6wscdsuG7iK3DZOQySrXOLWBq5Ct83KMrfdgm+DHKq3S4N6gxyqNwFDjGn8alAP+t0WfIN+NajH/AoYolXhV8AQD13m19emGEVoRdemTMjWpkxH16ZMiNemuOnjFYnTEMlIiVckTkMkAztxe6wscltt/CpzW238KnRr41ehWxu/Ct3qG5sHOVRvVYN6gxyqt6qTIqFfDepBv9uCb9CvBvWYXwFDPKUZMr8ChnjoMr++NsUoQmu6NmVCtjZlOro2ZUK8NsVNH69InIVIRkq8InEWIhnYidtjZZFbcVFFF245C5Gscolbmz0J3TYry9zq25oHOftuXYN6g5x9N8FCjGr8alAP+t0WfIN+NajH/AoWom7hV7AQD13m19emmBhomoVIhWxtynR0bcqE8JxJmj5ekTgLkYyUeEUSN1Ncxu2xssituLaiCrfi2opq3FaJ/0G3zcoyt/qu5kHOvptgIZ50Jzn7biYa4jJ+l9WFfrfl06DfY3WZX8FC1Cn8ChbiSRf69bUpJgaaZiFSoa7uDxrZ/UFNBEW8bmjaIpcJ8WoU92G8tHH6IRly8dLG6YdkhsRuOf2QTOjYLacfkvUncVulLHTbJEcI3XYpC90OC7pNcojetgbzJjlEbwJ+6Nv41WAe9Hss6Mb8Hg3mMb8v4Qd07c3ILtdop9659mZeiRqvQbWbhuxalzWkvr0vffIJI6nGU5fMK+2SJQt56mn7G39SreNqeaLTOd/weoN3TjQkI2LFstXKEvSgvyAa+P1E6aN3dz9ROvs7JxeS9SlpRAuvwkZcEgeFbi28Ct0eiYMyt8XCq8ytYBZG3Lgj1q1al7AQ3RAM0/jtWpf5HZZXhH6n1mV+l7xfZmb3dXQOOXyo1Tz60bro0atOPp4xjNKrTT5Ohaq7DyfvjCq/PE8d2S/PUyE8MZJOjJdJzickYy5eJutyt/e80hFb0q7wuY+VRc/NcYRkVYzdchohWcQTt1XSrtBts7LMrb6afBLUo7ehdQnq0du0OCb0u7Qu87stjgn9Hq2L/HbxCvsSfnvRusyvfoU9Y0Cmd/sKOxWSx6upjj1eTYV4OYqbPl6ROJGQjJR4ReJAQjKwE7fHyiK3HEdIlo3YLacRklUucVsl7QrdNivL3HaLY06CevQxtC5BPfqYFseEfpfWZX63xTGh36N1kd8pfhtt4XcWrcv8+toUAzJ96tqUCdnalOno2pQJ8ePVuOnjFYkTCclIiVckDiQkAztxe6wscstxhGTZiN1yGiFZ5RK3VdKu0G2zssytvrJ5EtSjL31l8yKoR1/T4pjQ77K60O+2OCb0e6wu87tFbZrC7y5WF/qt8MiwPG6xmewWm/6CbviX8g//9f2nn17Rby/1Y8Wu6+hOlIato5nQlHU001m2jmZCeL4kwyRePV/ACaAzXxkr8Sg88C6l3w+S3wn3WLjI5piEhek8oCFZPOJW5uRCstYlbrskiqHbIWWh2ymJYuh2SVnoVkdILgKb9KMjJBeBTcalIySR33HpCEnot1rkFfptWpf5FTWqG79D6zK/09bUFQMh47LEUCq0XU1NdY6sqZkQpx2Spl+xbLGyBKIYHHZIBnbitllZ5rZLEBi6HVaWuZ0SBIZul5VlbjWpugjzMIqOkFyEeRhVk6rMb9URktBvtUAo9KsBVuhX/36CfscN3VjJVyP25Lo2ZQZtbcp0dG0icMBoFmzN/HEmIhkp8YrULNgKH7tZWea2S4IUurW8K3Q7JUEK3VreFbrVEZKL8AWj6QjJRfiC0XWEJPPbdYQk9Fstlwj9Nq3L/PYbK3+sJKrRZZ58al325Lo2ZQ9ua1Omw2tT/JzxQsIJiaRb4oVkFF9JY6EqYU342M3KssfuErGEboeVZW7tterQ7bKyzK2OkFyELxhDR0guwheMqSMkmd+pIySh32oZQOi3aV3m19emmHIYItBhmwef6qhtPR2irIFO8oaIddimWbdy/fhmcc3kfHCYqy1e7SYBTLyuU9ix1u8e7e1TrcERibg/4tV0qQPbfBDFvc1BiXjkx0NTX3WRdpVlY2GbWjYWPrZlY6Fby8Yyt9uysczttmwsdFstZbkIwTF2s7qbEBxDUBHtMn6H1YV+p6Usod9ldaHffY9jWSurUyLpoTyPsFBJZDtM0ZTiXospWvLYm2vTx5bfD6Y6PCklfMx4XeJcRNwn8bJ0bP5Q+tBLoTy/G85gb8KBiGQWJo16pCxq1clxiGSNW7FskbLQbZXELXTbpCx02y0SugkKMQUK8dAlKMQUKETdxu/Suszvtkgo9Hu0LvJbLoua7gv9QJ1FX66+Y9RjFluiWJPqqy5Sf90Ksa6RIXmbYA2zSDg2feildcig2bKgpvbusbHfDu64bzgVkczGuHOqJWNZq1ZLxkK3loyFbi0ZC91aMha6nZax3ITfmIKOeOh2NHK3ZSyh36N1kV9x3UXpwq+47uKhy/zq7wp3jHtMfd1FKiQy8kwLDvcb/LHEFrZ/EGES1fQPf/kXqsaLS1PvI/KmSDwf6ZnQHrNfen8R69jD3lSoSvaW9Q2nI5IFJGm+Ltlb6HZYWeZ2SvYWul1WlrndFg7dBBeZXce5boKLTHPvRRd+zb0X3fj1RYr5bTd0YyV9vAuffNw639w9eW88Ta7E60+Mp9JlemRLVcJ4TA5NXKJvODIRt0C8lnBg4vX+mdWMnN8NnLff0E6OSSTDPe6oacP40qcfXoh0zpSQMHzsZWWZ2y0hYej2WFnkdmk6dhOwZS5Nx26Cnsyl6VjoV9Ox0O+dEhUraToWPrmmY+GTWzo2ffBtf+MRCGEu9fLvQ32s1YyamSJOIh6n8Xzl6IQZ/VuVrbwpEs9Nekbja8sgpGx4cVoiGf7x8OKwRDJbk7ZcfgsQC21JN8PHPlYWPTbHJZJqErvluERS/BK31eK3m9AdU9yP8aR7CN4xzf0Yl/E7rC70qz823DFSMY8FZOGD71tY715sQRURE5s36xIJEz2UXbGsjTFPOmtd1Qu93ZrrJUQBLizbWcrRumxFImNpXUOrxjryTBeOmeXgYDhk9h2g+dvpk3g+zjMbRsV+wZt1FGcikkUzblORLnGZx26SPIZuu5SFbjUaewgmssw9Gk+6BO9YRaOx0O/WuszvuYfcnuw6q+Wv0zhXomTZ2EOQgSWyJKboIRElEcvGE0AkSUzR73X4rUMsNP2lY6nW0hUv1tkOC4YdfKQqGo2chDDdyzkIMxY5BfHGzG7tFhi9D3rtvjgakayVSVcNK8tadUqCGbpdVpa51Smxh3Anq+mU2EPIkNV1Sizz23VKLPSrD3FPDF6s7lJhH1cYnco25SJGIu6veNh2+93uIezB6vZAF46C5WVjoW2F2Gg67iKxk91ftYbkilhvD3mMmzUfRx+6GDQcfDAr3ZCf57KedghEPtmTlrCfRKUdtSQLDceRzWKGA+BIFpq55UhENWucCJGocePGA3bqYNhDyJAlQiRKN351MCz0q8P3TsxdrBeAxA//+OW/P/4l1Sn/1lnI3/I1JBayB7iwX84ttPg0tkYte4DLen3JA9xD6JC16h20+NumSDzLA9zTUQN3vQWIdQYb/V8Hfyyja1LmZ0mUGHbxtrKsF45EiZlbjj8ktSN2uzXreggAsbYOhD0EUlj2Ko3HJ2bnmzyZpJk1XgTbY9zQjZX0WS1s2XWL0T1ZBtHa+idT9sSSez0EVVhHcq+snzkAEavGs5TzD5focZsdkfXPC9pBMLqHJTytYxlY2P26OmVPv7wQ6fIN74F5bs9v4LFkhB5J6aL23Jx1SOpIi2WLxUgPgQD2pbHXcpHz+321G8tzrNQtRwofXXOv9NH1O7zsyRf8+dWe7BVkb9/iUw+DIPYLCOJV0189hzJ/jIZg5OhhoNMu9n1e0kOcfciGULyKcPghGfLJY3dfQ2KhIWlM+txT6sLnXpYX/MZvvIYI3OFZmByM7qIDwX5zHEoJ0GGbZxfYwzaPXi2Nlz+53NjlQvJV+DdPGo92DjckHROP9mq3dPlz26xK+uBb67InP5Y++sZwPNbb5YXJcchuxc/z+Mhit3rrHPVLBUavBPYLGOL13chDdyQ+u57f2RMPO78zIfie++uTka5dd066gu5IhuTWszx7ehuk983YjgcMRxqyyRjPco80fGM4blLDNDyEybv53W9efFuulrxV2v52jN8aIZYaekJmStNOyExo6cGdKe1bCNe/W/7t1zJbXI2RDJl48oxL65IX3fsFyfDGkd7jB9qJG9anOPz25LFU0wMwU+p2AGZCQw/ATAnWlhftDVaU4d5SP78dK9di1V7cePHcAsmPxXF09yZK87LdmwkV3b2ZUpXvJ4MeiKvR1G/QSkn28VNvuVIlu+VKhfSPlFRp+XZKdkJz63bKlI5tp0RoXbqdMiX/U6MkRXXpn+ipkv2Jngp13U6Z0vDtlKz9a+p2ypSWbadMSP9sSJX8K6qSLKL70u2UKRX1zeUXnWyDvatt8cxS0y2eKXUal/y8ja1X+nx+mNdkBd4T+hrAloXDclfbf/GTi9n1PBM6151D4lLYJyX76I1NarTe++GEnfrtTU0q29Hbm1RpOA691AxE38f+Fk496d/Cvyn9nz999+nXjz/+Nvg//+Pjz798+unXL//gvz/+8vd//f9n73Vc59T5pQr+P+wQSCQ=";

        private BlueprintFactory testee;
        private BlueprintUtilities utilities;

        public PlueprintFactoryTests()
        {
            testee = new BlueprintFactory();
            utilities = new BlueprintUtilities();
        }

        [TestMethod]
        public async Task GetBlueprint_ReturnBlueprintToJson()
        {
            var blueprint = await utilities.GetBlueprint(BlueprintString).ConfigureAwait(false);
            var result = new List<Item>();

            foreach (var jsonEntity in blueprint.Entities)
            {
                var domainEntity = testee.GetDomainEntity(jsonEntity);
                domainEntity.ShouldNotBeNull();
                result.Add(domainEntity);
            }
        }
    }
}
